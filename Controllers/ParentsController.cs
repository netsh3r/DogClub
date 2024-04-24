using DogClub.Entities;

namespace DogClub.Controllers;

public class ParentsController : BaseController<Parents>
{
    public ParentsController(EntityRepository<Parents> repository) : base(repository)
    {
    }
}