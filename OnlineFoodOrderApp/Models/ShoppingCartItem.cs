namespace OnlineFoodOrderApp.Models;

public class ShoppingCartItem
{
    public int ShoppingCartItemId { get; set; }
    public Food food { get; set; }
    public int Amount { get; set; }
    public string ShoppingCartId { get; set; }
}