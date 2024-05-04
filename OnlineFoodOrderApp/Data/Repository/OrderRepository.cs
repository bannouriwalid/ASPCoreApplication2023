using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Repository;

public class OrderRepository : IOrderRepository
{
    private readonly AppDbContext _appDbContext;
    private readonly ShoppingCart _shoppingCart;


    public OrderRepository(AppDbContext appDbContext, ShoppingCart shoppingCart)
    {
        _appDbContext = appDbContext;
        _shoppingCart = shoppingCart;
    }


    public void CreateOrder(Order order)
    {
        order.OrderPlaced = DateTime.Now;

        _appDbContext.Orders.Add(order);

        _appDbContext.SaveChanges();

        var shoppingCartItems = _shoppingCart.ShoppingCartItems;

        foreach (var shoppingCartItem in shoppingCartItems)
        {
            var orderDetail = new OrderDetail()
            {
                Amount = shoppingCartItem.Amount,
                FoodId = shoppingCartItem.food.FoodId,
                OrderId = order.OrderId,
                Price = shoppingCartItem.food.Price
            };

            _appDbContext.OrderDetails.Add(orderDetail);
        }

        _appDbContext.SaveChanges();
    }
}