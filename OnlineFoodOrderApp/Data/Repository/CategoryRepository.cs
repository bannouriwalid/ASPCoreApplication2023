using OnlineFoodOrderApp.Data.Interfaces;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Repository;

public class CategoryRepository : ICategoryRepository
{
    private readonly AppDbContext _appDbContext;
    public CategoryRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public IEnumerable<Category> Categories => _appDbContext.Categories;
}
