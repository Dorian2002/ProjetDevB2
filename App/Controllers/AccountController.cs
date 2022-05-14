using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using App.Models;
using App.ViewModels;
using App.Areas.Identity.Data;

namespace App.Controllers;
public class AccountController : Controller
{
    
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> userManager;
    private readonly SignInManager<ApplicationUser> signInManager;
    public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signInManager, ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }

    [HttpGet]
    public IActionResult Register()
    {
        return View("../Account/Register");
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterRequest model)
    {
        if (ModelState.IsValid){
            var user = new ApplicationUser {UserName = model.UserName, Email = model.Email, EmailConfirmed = true };
            var result = await userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await userManager.AddToRoleAsync(user, "User");
                await signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach(var error in result.Errors){
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View("../Account/Login");
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginRequest model)
    {
        if (ModelState.IsValid){
            var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            Console.WriteLine(result.Succeeded);
            ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Logout()
    {
        await signInManager.SignOutAsync();
        return RedirectToAction("Index","Home");
    }

    [HttpGet]
    public IActionResult Profile(int Id, bool modifiedByAdmin)
    {
        if (signInManager.IsSignedIn(User)){
            var user = userManager.FindByIdAsync(Id.ToString());
            ProfileRequest model = new() { OldUserName=user.Result.UserName, UserName=user.Result.UserName, Email=user.Result.Email, ModifiedByAdmin=modifiedByAdmin};
            return View("../Account/Profile", model);
        }
        return RedirectToAction("Index", "Home");
    }

    [HttpPost]
    public async Task<IActionResult> EditProfile(ProfileRequest model)
    {
        if (ModelState.IsValid){
            var user = userManager.FindByNameAsync(model.OldUserName).Result;
            if (model.NewPassword != "" && model.NewPassword != null){
                var newPasswordHash = userManager.PasswordHasher.HashPassword(userManager.FindByNameAsync(model.OldUserName).Result,model.NewPassword);
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.PasswordHash = newPasswordHash;
                _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = await userManager.UpdateAsync(user);
                foreach(var err in result.Errors){
                    if (err.Code == "DuplicateUserName"){
                        ModelState.AddModelError("UserName","This username is already used.");
                    }
                    if (err.Code == "DuplicateEmail"){
                        ModelState.AddModelError("Email","This email is already used.");
                    }
                }
                if (result.Succeeded && !model.ModifiedByAdmin)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                }
                else if (result.Succeeded)
                {
                    return RedirectToAction("UserManager", "Administration");
                }
                else if (!result.Succeeded)
                {
                    return View("../Account/Profile", model);
                }
            }else{
                user.Email = model.Email;
                user.UserName = model.UserName;
                _dbContext.Entry(user).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                var result = await userManager.UpdateAsync(user);
                foreach(var err in result.Errors){
                    if (err.Code == "DuplicateUserName"){
                        ModelState.AddModelError("UserName","This username is already used.");
                    }
                    if (err.Code == "DuplicateEmail"){
                        ModelState.AddModelError("Email","This email is already used.");
                    }
                }
                if (result.Succeeded && !model.ModifiedByAdmin)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                }
                else if (result.Succeeded)
                {
                    return RedirectToAction("UserManager", "Administration");
                }
                else if (!result.Succeeded)
                {
                    return View("../Account/Profile", model);
                }
            }
            return RedirectToAction("Index", "Home");
        }else{
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach(var e in errors){
                Console.WriteLine(e.ErrorMessage);
            }
            return View("../Account/Profile", model);
        }
    }
}