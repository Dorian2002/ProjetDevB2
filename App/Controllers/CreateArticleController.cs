using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using App.ViewModels;

namespace App.Controllers;
public class CreateArticleController : Controller
{
    [HttpPost]
    public ActionResult Create(CreateArticle _article){
        Console.WriteLine(_article.Name + " :");
        Console.WriteLine(_article.Description);
        Console.WriteLine(User);
        return View("../Seller/CreateArticle");
    }
}
