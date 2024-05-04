using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data.Interfaces;

public interface ICategoryRepository
{
    IEnumerable<Category> Categories { get;}
}