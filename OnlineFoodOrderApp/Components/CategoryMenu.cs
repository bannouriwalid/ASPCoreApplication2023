using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Components;

public class CategoryMenu:ViewComponent
{
    private readonly ICategoryRepository _categoryRepository;
    public CategoryMenu(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public IViewComponentResult Invoke()
    {
        var categories = _categoryRepository.Categories.OrderBy(p => p.CategoryName);
        return View(categories);
    }
}