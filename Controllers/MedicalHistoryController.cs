using DogClub.Entities;

namespace DogClub.Controllers;

public class MedicalHistoryController : BaseController<MedicalHistory>
{
    public MedicalHistoryController(EntityRepository<MedicalHistory> repository) : base(repository)
    {
    }
}