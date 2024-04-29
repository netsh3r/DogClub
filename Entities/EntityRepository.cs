using System.Linq.Expressions;
using System.Reflection;
using DogClub.Entities.Repositories;
using DogClub.Extensions;
using DogClub.Models;
using Microsoft.EntityFrameworkCore;

namespace DogClub.Entities;

public class EntityRepository<TEntity> : IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    private readonly EfCoreDbContext _context;
    public readonly DbSet<TEntity> DbSet;
    public IQueryable<TEntity> DbQuery => DbSet.AsNoTracking();

    public EntityRepository(EfCoreDbContext context)
    {
        _context = context;
        DbSet = context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        await DbSet.AddAsync(entity, cancellationToken);
        await SaveChangeAsync(cancellationToken);
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken)
    {
        var entityL = DbSet.Local.FirstOrDefault(x => x.Id == entity.Id);
        if (entityL is null)
        {
            DbSet.Update(entity);
        }
        else
        {
            _context.Entry(entityL).CurrentValues.SetValues(entity);
        }
        
        await SaveChangeAsync(cancellationToken);
        return entity;
    }
    
    public async Task SaveChangeAsync(CancellationToken cancellationToken = default)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }


    public void Delete(TEntity entity)
    {
        DbSet.Remove(entity);
    }

    public async Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken)
    {
        return await DbSet.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public async Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        if (entity.Id == 0)
        {
            return await AddAsync(entity, cancellationToken);
        }

        return await Update(entity, cancellationToken);
    }

    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(
        CancellationToken cancellationToken = default)
    {
        var query = DbQuery;

        return await query.ToListAsync(cancellationToken);
    }
    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(int[] ids,
        CancellationToken cancellationToken = default)
    {
        var query = DbQuery.Where(x => ids.Contains(x.Id));

        return await query.ToListAsync(cancellationToken);
    }
    
    public async Task<IReadOnlyCollection<TEntity>> GetAllAsync(
        IEnumerable<(string propName, object propValue)>? conditionList, SortModel? sort,
        CancellationToken cancellationToken = default)
    {
        var query = DbQuery;
        if (conditionList is not null)
        {
            foreach (var condition in conditionList)
            {
                var mba = PropertyAccessorCache<TEntity>.Get(condition.propName);
                var value = Convert.ChangeType(condition.propValue, mba.ReturnType);
                var eqe = Expression.Equal(mba.Body, Expression.Constant(value, mba.ReturnType));
                var expressionCond = Expression.Lambda(eqe, mba.Parameters[0]);
                MethodCallExpression resultExpressionCond = Expression.Call(
                    null,
                    GetMethodInfo(Queryable.Where, query, (Expression<Func<TEntity, bool>>)null),
                    new Expression[] { query.Expression, Expression.Quote(expressionCond) });
                query = query.Provider.CreateQuery<TEntity>(resultExpressionCond);
            }
        }
        

        if (sort != null)
        {
            var expression = PropertyAccessorCache<TEntity>.Get(sort.PropertyName);
            var resultExpression = Expression.Call(
                typeof(Queryable),
                sort.SortType == SortType.Asc ? nameof(Queryable.OrderBy) : nameof(Queryable.OrderByDescending),
                new Type[] { typeof(TEntity), expression.ReturnType },
                query.Expression,
                Expression.Quote(expression));
            query = query.Provider.CreateQuery<TEntity>(resultExpression);
        }

        return await query.ToListAsync(cancellationToken);
    }

    private static MethodInfo GetMethodInfo<T1, T2, T3>(
        Func<T1, T2, T3> f,
        T1 unused1,
        T2 unused2)
    {
        return f.Method;
    }
}