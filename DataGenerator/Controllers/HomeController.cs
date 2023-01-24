using DataGenerator.Models;
using DataGenerator.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace DataGenerator.Controllers
{
  public class HomeController : Controller
  {
    private readonly ILogger<HomeController> _logger;
    private readonly IPeopleService peopleService;
    public HomeController(ILogger<HomeController> logger, IPeopleService peopleService)
    {
      _logger = logger;
      this.peopleService = peopleService?? throw new ArgumentNullException(nameof(peopleService));
    }

    public async Task<IActionResult> Index()
    {
      await peopleService.GenerateData();
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
  }
}