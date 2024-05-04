using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Interfaces;

public interface IOrderRepository
{
    void CreateOrder(Order order);
}