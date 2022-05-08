using App.Models;
using Microsoft.EntityFrameworkCore;

namespace App.Areas.Identity.Data;
public static class AppIdentityDbContextExtension
{
     public static void Seed(this ApplicationDbContext dbContext)
    {
        var Categories = new List<Category>() {
            new Category(){
                Name ="Bricolage",
            },
            new Category(){
                Name ="Jardinage",
            },
            new Category(){
                Name ="Mécanique",
            },
            new Category(){
                Name ="Vêtement",
            },
            new Category(){
                Name ="Mobilier",
            },
            new Category(){
                Name ="Electroménager",
            },
        };
        dbContext.Categories.AddRange(Categories);
        dbContext.SaveChanges();
    }
}