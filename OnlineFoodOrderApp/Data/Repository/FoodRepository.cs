using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Repository;

public class FoodRepository : IFoodRepository
{
    private readonly AppDbContext _appDbContext;
    public FoodRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public IEnumerable<Food> Foods => _appDbContext.Foods.Include(c => c.Category);

    public IEnumerable<Food> PreferredFoods => _appDbContext.Foods.Where(p => p.IsPreferredFoods).Include(c => c.Category);

    public Food GetFoodById(int foodId) => _appDbContext.Foods.FirstOrDefault(p => p.FoodId == foodId);
}