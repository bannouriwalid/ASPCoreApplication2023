﻿using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Models;
using OnlineFoodOrderApp.ViewModels;

namespace OnlineFoodOrderApp.Components;

public class ShoppingCartSummary:ViewComponent
{
    private readonly ShoppingCart _shoppingCart;
    public ShoppingCartSummary(ShoppingCart shoppingCart)
    {
        _shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
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


}