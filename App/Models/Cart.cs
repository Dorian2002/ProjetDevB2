using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public Article Article {get; set; }
        public DateTime AddDate { get; set; }
    }
}