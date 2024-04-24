using DogClub.Entities;

namespace DogClub.Controllers;

public class ShowsController : BaseController<Shows>
{
    public ShowsController(EntityRepository<Shows> repository) : base(repository)
    {
    }
}