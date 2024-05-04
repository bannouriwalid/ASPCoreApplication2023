using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.ViewModels;

public class ShoppingCartViewModel
{
    public ShoppingCart ShoppingCart { get; set; }
    public decimal ShoppingCartTotal { get; set; }
}