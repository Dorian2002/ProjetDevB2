using App.Areas.Identity.Data;
using App.Models;
using App.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class ArticlesController : Controller
    {
        
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _dbContext;

        public ArticlesController(UserManager<ApplicationUser> userManager, ApplicationDbContext dbContext){
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            var inCart = _dbContext.Carts.Where(c => c.User.UserName == User.Identity.Name && c.Article.Id == id);
            var article = _dbContext.Articles.Include(a => a.Seller).Include(a => a.Categories).First(a => a.Id == id);
            return View("../Articles/Details", new ArticleDetails(){Article = article, InCart = inCart.Any()});
        }

        [HttpGet]
        public IActionResult Cart()
        {
            var articles = _dbContext.Carts.Include(c => c.Article).Where(c => c.User.UserName == User.Identity.Name);
            float totalPrice = 0;
            foreach(var item in articles){
                totalPrice += item.Article.Price;
            }
            return View("../Articles/Cart", new CartArticles(){Articles = articles, TotalPrice = totalPrice});
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(ArticleDetails model)
        {
            Cart toAdd = new(){
                User = _userManager.FindByNameAsync(User.Identity.Name).Result,
                Article = _dbContext.Articles.First(a => a.Id == model.Article.Id),
                AddDate = DateTime.Now,
            };
            await _dbContext.Carts.AddAsync(toAdd);
            _dbContext.SaveChanges();
            return RedirectToAction("Cart");
        }

        [HttpGet]
        public async Task<IActionResult> RemoveFromCart(int cartId)
        {
            Cart toRemove = _dbContext.Carts.First(c => c.Id == cartId);
            _dbContext.Carts.Remove(toRemove);
            _dbContext.SaveChanges();
            return RedirectToAction("Cart");
        }
        [HttpPost]
        public async Task<IActionResult> Search(string searchString)
        {
            var articles = from m in _dbContext.Articles
                        select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                articles = articles.Where(s => s.Name!.Contains(searchString));
            }

            return View(await articles.ToListAsync());
        }

    }
}