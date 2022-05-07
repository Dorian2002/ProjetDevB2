using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using App.Models;
using App.ViewModels;

namespace App.Controllers;
public class AccountController : Controller
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View("../Account/Login");
    }
    [HttpGet]
    public IActionResult Register()
    {
        return View("../Account/Register");
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        if (ModelState.IsValid){
            var user = new ApplicationUser {UserName = model.Email, Email = model.Email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach(var error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (ModelState.IsValid){
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
            Console.WriteLine(model.RememberMe);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }
        return View(model);
    }
}