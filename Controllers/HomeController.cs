using System.Diagnostics;
using DogClub.Entities;
using Microsoft.AspNetCore.Mvc;
using DogClub.Models;
using DogClub.Services;

namespace DogClub.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly DogService _dogService;

    public HomeController(ILogger<HomeController> logger, DogService dogService)
    {
        _logger = logger;
        _dogService = dogService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    
    public  async Task<IActionResult> BaseMating(int dogId, CancellationToken cancellationToken)
    {
        return View("BaseMating", await _dogService.GetBaseDogMating(dogId, cancellationToken));
    }
    
    public  async Task<IActionResult> PremiumMating(int dogId, CancellationToken cancellationToken)
    {
        return View("BaseMating", await _dogService.GetPremiumDogMating(dogId, cancellationToken));
    }
    
    public  async Task<IActionResult> SpecialMating(int dogId, CancellationToken cancellationToken)
    {
        return View("BaseMating", await _dogService.GetSpecialDogMating(dogId, cancellationToken));
    }
}