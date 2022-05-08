using Microsoft.AspNetCore.Identity;

namespace App.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public ApplicationUser User;
        public ApplicationUser Seller;
    }
}