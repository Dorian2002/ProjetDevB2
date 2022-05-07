using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Favourite
    {
        public int Id { get; set; }
        public ApplicationUser User { get; set; }
        public int ArticleId { get; set; }
    }
}