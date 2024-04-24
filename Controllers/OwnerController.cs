using DogClub.Entities;

namespace DogClub.Controllers;

public class OwnerController : BaseController<Owner>
{
    public OwnerController(EntityRepository<Owner> repository) : base(repository)
    {
    }
}