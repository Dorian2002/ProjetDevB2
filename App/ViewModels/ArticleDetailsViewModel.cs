using System.ComponentModel.DataAnnotations;
using App.Models;

namespace App.ViewModels
{
    public class ArticleDetails
    {
        [Required]
        public Article Article { get; set; }

        [Required]
        public bool InCart { get; set; }
    }
}