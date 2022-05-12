using App.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace App.Controllers;

public class StoreController : Controller
{
    private readonly ApplicationDbContext _dbContext;

    public StoreController(ApplicationDbContext dbContext){
        _dbContext = dbContext;
    }

    [HttpGet]
    public IActionResult UserStore(int Id)
    {
        Console.WriteLine(Id);
        var Articles = _dbContext.Articles.Include(a => a.Seller).Where(a => a.Seller.Id == Id).OrderBy(a => a.CreationDate).ToList();
        return View("../Articles/Store", Articles);
    }
}
