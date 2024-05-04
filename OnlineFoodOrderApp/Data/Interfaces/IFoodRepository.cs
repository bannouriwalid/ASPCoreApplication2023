using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Interfaces;

public interface IFoodRepository
{
    IEnumerable<Food> Foods { get; }
    IEnumerable<Food> PreferredFoods { get; }
    Food GetFoodById(int foodId);
}