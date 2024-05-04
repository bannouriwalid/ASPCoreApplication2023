using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.ViewModels;

public class HomeViewModel
{
    public IEnumerable<Food> PreferredFoods { get; set; }
}