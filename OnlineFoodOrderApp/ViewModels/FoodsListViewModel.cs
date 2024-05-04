using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.ViewModels;

public class FoodsListViewModel
{
    public IEnumerable<Food> Foods { get; set; }
    public string CurrentCategory { get; set; }
}