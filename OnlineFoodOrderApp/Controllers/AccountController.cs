using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderApp.Data;
using OnlineFoodOrderApp.ViewModels;

namespace OnlineFoodOrderApp.Controllers;

public class AccountController : Controller
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly AppDbContext _appDbContext;

    public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager,
        AppDbContext appDbContext)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _appDbContext = appDbContext;
    }

    public IActionResult Login()
    {
        return View(new LoginViewModel());
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid)
            return View(loginViewModel);
        var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
        if (user != null)
        {
            var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
        }
        ModelState.AddModelError("", "Username/password not found");
        return View(new LoginViewModel());
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(LoginViewModel loginViewModel)
    {
        if (!ModelState.IsValid) return View(loginViewModel);
        var user = new IdentityUser() { UserName = loginViewModel.UserName };
        var result = await _userManager.CreateAsync(user, loginViewModel.Password);

        if (result.Succeeded)
        {
            await _appDbContext.SaveChangesAsync();
            return RedirectToAction("LoggedIn", "Account");
        }
        foreach (var error in result.Errors)
        {
            ModelState.AddModelError("", error.Description);
        }
        return View(new LoginViewModel());
    }

    public ViewResult LoggedIn()
    {
        return View();
    }


    [HttpPost]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Home", "Home");
    }
}