using DogClub.Entities;

namespace DogClub.Controllers;

public class DiseasesController : BaseController<Diseases>
{
    public DiseasesController(EntityRepository<Diseases> repository) : base(repository)
    {
    }
}