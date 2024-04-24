namespace DogClub.Entities.Repositories.Implementations;

public class BreedRepository : EntityRepository<Breeds>, IEntityRepository<Breeds>
{
    public BreedRepository(EfCoreDbContext context) : base(context)
    {
    }
}