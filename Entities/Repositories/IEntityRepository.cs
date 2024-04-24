using DogClub.Models;
using Microsoft.EntityFrameworkCore;

namespace DogClub.Entities.Repositories;

public interface IEntityRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity entity, CancellationToken cancellationToken);
    void Delete(TEntity entity);
    Task<TEntity?> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<TEntity> AddOrUpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    Task<IReadOnlyCollection<TEntity>> GetAllAsync(
        IEnumerable<(string propName, object propValue)>? conditionList, SortModel? sort,
        CancellationToken cancellationToken = default);
}