namespace App.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public User User;
        public Seller Seller;
    }
}