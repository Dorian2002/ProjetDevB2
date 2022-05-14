using App.Areas.Identity.Data;
using App.Models;
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
        var Articles = _dbContext.Articles.Include(a => a.Seller).Where(a => a.Seller.Id == Id).OrderBy(a => a.CreationDate).ToList();
        return View("../Articles/Store", Articles);
    }

    [HttpGet]
    public IActionResult DeleteFromStore(int articleId)
    {
        Article toRemove = _dbContext.Articles.Include(a => a.Seller).First(a => a.Id == articleId);
        _dbContext.Articles.Remove(toRemove);
        _dbContext.SaveChanges();
        return RedirectToAction("UserStore", toRemove.Seller.Id);
    }
}
