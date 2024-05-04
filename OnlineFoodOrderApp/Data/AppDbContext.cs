using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

public class AppDbContext : IdentityDbContext<IdentityUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
    public DbSet<Food> Foods { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    
    public DbSet<Order> Orders { get; set; }
    
    public DbSet<OrderDetail> OrderDetails { get; set; }
    
    public DbSet<Contact> Contacts { get; set; }
}

