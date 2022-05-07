namespace App.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public IdentityUser User;
        public IdentityUser Seller;
    }
}