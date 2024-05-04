using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;
using OnlineFoodOrderApp.ViewModels;

namespace OnlineFoodOrderApp.Controllers;

public class FoodController : Controller
{
    // GET
    private readonly IFoodRepository _foodRepository;
    private readonly ICategoryRepository _categoryRepository;

    public FoodController(IFoodRepository foodRepository, ICategoryRepository categoryRepository)
    {
        _foodRepository = foodRepository;
        _categoryRepository = categoryRepository;
    }

    public ViewResult List(string category)
    {
        var value = category;
        IEnumerable<Food> foods;
        string currentCategory;

        if (string.IsNullOrEmpty(category))
        {
            foods = _foodRepository.Foods.OrderBy(p => p.FoodId);
            currentCategory = "All foods";
        }
        else
        {
            foods = _foodRepository.Foods.Where(p => p.Category.CategoryName.Equals(value)).OrderBy(p => p.Name);
            currentCategory = value;
        }

        return View(new FoodsListViewModel
        {
            Foods = foods,
            CurrentCategory = currentCategory
        });
    }

    public IActionResult Details(int foodId)
    {
        var food = _foodRepository.Foods.FirstOrDefault(d => d.FoodId == foodId);
        if (food == null)
        {
            return View("~/Views/Error/Error.cshtml");
        }

        return View(food);
    }

    public ViewResult Search(string searchString)
    {
        var value = searchString;
        IEnumerable<Food> foods;
        var currentCategory = string.Empty;

        if (string.IsNullOrEmpty(value))
        {
            foods = _foodRepository.Foods.OrderBy(p => p.FoodId);
        }
        else
        {
            foods = _foodRepository.Foods.Where(p => p.Name.ToLower().Contains(value.ToLower()));
        }

        return View("~/Views/Food/List.cshtml",
            new FoodsListViewModel { Foods = foods, CurrentCategory = "All foods" });
    }
}