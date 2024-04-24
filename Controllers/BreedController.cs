using DogClub.Entities;

namespace DogClub.Controllers;

public class BreedController : BaseController<Breeds>
{
    public BreedController(EntityRepository<Breeds> repository) : base(repository)
    {
    }
}