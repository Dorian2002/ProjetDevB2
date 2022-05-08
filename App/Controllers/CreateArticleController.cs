using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using App.Models;
using App.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace App.Controllers;
public class CreateArticleController : Controller
{
    private readonly ApplicationDbContext _dbContext;
    private readonly UserManager<ApplicationUser> _userManager;
    public CreateArticleController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult CreateArticle()
    {
        //IEnumerable<SelectListItem> Categories = new MultiSelectList(dbContext.Categories, "Id", "Name");
        ViewBag.Categories = new MultiSelectList(_dbContext.Categories, "Id", "Name");
        return View("../Seller/CreateArticle");
    }

    [HttpPost]
    public async Task<ActionResult> Create(CreateArticle _article, List<uint> catogoryList){
        ModelState.Remove("Categories");
        if (ModelState.IsValid)
        {
            _article.Categories = new List<Category>();
            foreach(var id in catogoryList){
                _article.Categories.Add(_dbContext.Categories.FirstOrDefault(c => c.Id == id));
            }
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            Article newArticle = new()
            {
                Seller = user,
                CreationDate = DateTime.Now,
                Name = _article.Name,
                Price = _article.Price,
                Description = _article.Description,
                Location = _article.Location,
                Categories = _article.Categories,
            };
            _dbContext.Articles.Add(newArticle);
            _dbContext.SaveChanges();
        }else{
            var errors = ModelState.Values.SelectMany(v => v.Errors);
            foreach(var e in errors){
                Console.WriteLine(e.ErrorMessage);
            }
        }
        ViewBag.Categories = new MultiSelectList(_dbContext.Categories, "Id", "Name");
        return View("../Seller/CreateArticle");
    }
}
