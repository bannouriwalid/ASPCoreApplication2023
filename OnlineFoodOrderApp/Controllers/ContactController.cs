using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data;
using OnlineFoodOrderApp.Models;

namespace OnlineFoodOrderApp.Controllers;

public class ContactController : Controller
{

    private readonly AppDbContext _appDbContext;
    public ContactController(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(Contact contact)
    {
        _appDbContext.Contacts.Add(contact);
        _appDbContext.SaveChanges();
        return View("~/Views/Home/Home.cshtml");
    }
}