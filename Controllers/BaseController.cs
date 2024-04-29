using DogClub.Dto;
using DogClub.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DogClub.Controllers;

public class BaseController<TEntity> : Controller
    where TEntity : BaseEntity, new()
{
    protected readonly EntityRepository<TEntity> _repository;

    public BaseController(EntityRepository<TEntity> repository)
    {
        _repository = repository;
    }
    
    public async Task<IActionResult> Index(CancellationToken cancellationToken)
    {
        var data = await _repository.GetAllAsync(null, null, cancellationToken);
        var indexDto = new IndexDto();
        var head = new List<Head>();
        foreach (var prop in typeof(TEntity).GetProperties()
                     .Where(x => x.PropertyType.IsClass == false || x.PropertyType == typeof(string)))
        {
            head.Add(new Head()
            {
                Name = prop.Name,
                Description = prop.Name
            });
        }

        return View(new IndexDto
        {
            Head = head.ToArray(),
            Value = data.ToArray()
        });
    }

    public async Task<IActionResult> Edit(int id, CancellationToken cancellationToken)
    {
        var data = await _repository.GetByIdAsync(id, cancellationToken);
        return View(data);
    }

    public async Task<IActionResult> Change(TEntity entity, CancellationToken cancellationToken)
    {
        var t = await _repository.AddOrUpdateAsync(entity, cancellationToken);
        return View("Edit", t);
    }

    public IActionResult Create()
    {
        return View(new TEntity());
    }

    public async Task<IActionResult> Save(TEntity entity, CancellationToken cancellationToken)
    {
        var t = await _repository.AddOrUpdateAsync(entity, cancellationToken);
        return View("Edit", t);
    }
}