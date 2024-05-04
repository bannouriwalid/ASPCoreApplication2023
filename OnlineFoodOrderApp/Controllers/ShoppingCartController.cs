using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;
using OnlineFoodOrderApp.ViewModels;

namespace OnlineFoodOrderApp.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IFoodRepository _foodRepository;
    private readonly ShoppingCart _shoppingCart;

    public ShoppingCartController(IFoodRepository foodRepository, ShoppingCart shoppingCart)
    {
        _foodRepository = foodRepository;
        _shoppingCart = shoppingCart;
    }

    [Authorize]
    public ViewResult Index()
    {
        var items = _shoppingCart.GetShoppingCartItems();
        _shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel
        {
            ShoppingCart = _shoppingCart,
            ShoppingCartTotal = _shoppingCart.GetShoppingCartTotal()
        };
        return View(shoppingCartViewModel);
    }

    [Authorize]
    public RedirectToActionResult AddToShoppingCart(int foodId)
    {
        var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == foodId);
        if (selectedFood != null)
        {
            _shoppingCart.AddToCart(selectedFood, 1);
        }
        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int foodId)
    {
        var selectedFood = _foodRepository.Foods.FirstOrDefault(p => p.FoodId == foodId);
        if (selectedFood != null)
        {
            _shoppingCart.RemoveFromCart(selectedFood);
        }
        return RedirectToAction("Index");
    }
}