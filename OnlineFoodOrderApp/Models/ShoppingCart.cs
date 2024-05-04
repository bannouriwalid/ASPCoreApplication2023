using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderApp.Data;

namespace OnlineFoodOrderApp.Models;

public class ShoppingCart
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly AppDbContext _appDbContext;

    public ShoppingCart(IHttpContextAccessor httpContextAccessor, AppDbContext appDbContext)
    {
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
        _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
    }

    public string ShoppingCartId { get; set; }
    public List<ShoppingCartItem> ShoppingCartItems { get; set; }

    public static ShoppingCart GetCart(IServiceProvider services)
    {
        var httpContextAccessor = services.GetRequiredService<IHttpContextAccessor>();
        ISession session = httpContextAccessor.HttpContext.Session;

        var context = services.GetService<AppDbContext>();
        string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

        session.SetString("CartId", cartId);

        return new ShoppingCart(httpContextAccessor, context) { ShoppingCartId = cartId };
    }

    public void AddToCart(Food food, int amount)
    {
        var shoppingCartItem =
            _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.food.FoodId == food.FoodId && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                food = food,
                Amount = 1
            };

            _appDbContext.ShoppingCartItems.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }

        _appDbContext.SaveChanges();
    }

    public int RemoveFromCart(Food food)
    {
        var shoppingCartItem =
            _appDbContext.ShoppingCartItems.SingleOrDefault(
                s => s.food.FoodId == food.FoodId && s.ShoppingCartId == ShoppingCartId);

        var localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                _appDbContext.ShoppingCartItems.Remove(shoppingCartItem);
            }
        }

        _appDbContext.SaveChanges();

        return localAmount;
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        
               ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
                   .Include(s => s.food)
                   .ToList();
               return ShoppingCartItems;
    }

    public void ClearCart()
    {
        var cartItems = _appDbContext
            .ShoppingCartItems
            .Where(cart => cart.ShoppingCartId == ShoppingCartId);

        _appDbContext.ShoppingCartItems.RemoveRange(cartItems);

        _appDbContext.SaveChanges();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = _appDbContext.ShoppingCartItems.Where(c => c.ShoppingCartId == ShoppingCartId)
            .Select(c => c.food.Price * c.Amount).Sum();
        return total;
    }
}