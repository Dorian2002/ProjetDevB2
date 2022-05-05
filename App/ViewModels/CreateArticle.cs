using System.ComponentModel.DataAnnotations;
using App.Models;

namespace App.ViewModels
{
    public class CreateArticle
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public ICollection<Category> Categories { get; set; }

        [Required]
        public string Location { get; set; }
    }
}