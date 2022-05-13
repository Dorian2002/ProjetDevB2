using System.ComponentModel.DataAnnotations;
using App.Models;

namespace App.ViewModels
{
    public class CartArticles
    {
        [Required]
        public IQueryable<Cart> Articles { get; set; }

        [Required]
        public float TotalPrice { get; set; }
    }
}