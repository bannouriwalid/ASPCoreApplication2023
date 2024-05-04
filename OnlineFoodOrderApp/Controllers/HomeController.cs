using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.ViewModels;

namespace OnlineFoodOrderApp.Controllers;

public class HomeController : Controller
{
    private readonly IFoodRepository _foodRepository;
    public HomeController(IFoodRepository foodRepository)
    {
        _foodRepository = foodRepository;
    }

    public ViewResult Index()
    {
        var homeViewModel = new HomeViewModel
        {
            PreferredFoods = _foodRepository.PreferredFoods
        };
        return View(homeViewModel);
    }
    
    public IActionResult Home()
    {
        return View();
    }
}