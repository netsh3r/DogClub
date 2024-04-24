using DogClub.Entities;

namespace DogClub.Controllers;

public class DogController : BaseController<Dogs>
{
    public DogController(EntityRepository<Dogs> repository) : base(repository)
    {
    }
}