using App.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public ArticlesController(ApplicationDbContext dbContext){
            _dbContext = dbContext;
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Console.WriteLine(id);
            var article = _dbContext.Articles.Include(a => a.Seller).Include(a => a.Categories).First(a => a.Id == id);
            return View("../Articles/Details", article);
        }
    }
}