using Microsoft.AspNetCore.Mvc;

namespace OnlineFoodOrderApp.Controllers;

public class AboutController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}