namespace App.Models
{
    public class Message
    {
        public int Id { get; set; }
        public Chat Chat;
        public string MessageText;
        public DateTime MessageDate;
    }
}