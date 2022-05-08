using Microsoft.AspNetCore.Mvc;

namespace App.Controllers
{
    public class ArticlesController : Controller
    {
        [HttpGet]
        public IActionResult Details()
        {
            return View("../Articles/Details");
        }
    }
}