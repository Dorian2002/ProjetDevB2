using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Article
    {
        public int Id { get; set; }
        public ApplicationUser Seller { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
        public ICollection<Category> Categories { get; set; }
        public string Location { get; set; }
        public DateTime CreationDate { get; set; }
    }
}