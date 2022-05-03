namespace ProjetDevB2MarketPlace.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Article Article {get; set; }
        public DateTime AddDate { get; set; }
    }
}