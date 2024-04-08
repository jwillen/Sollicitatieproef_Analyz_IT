using Microsoft.AspNetCore.Mvc;

namespace Sollicitatieproef.Core.Controllers;

public class HomeController(ILogger<HomeController> logger) : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}