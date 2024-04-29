using DogClub.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DogClub.Controllers;

public class DogController : BaseController<Dogs>
{
    public DogController(EntityRepository<Dogs> repository) : base(repository)
    {
    }

    public Task<IReadOnlyCollection<Dogs>> GetAllDogs()
    {
        return _repository.GetAllAsync();
    }
}