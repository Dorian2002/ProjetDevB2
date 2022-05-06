using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class AddAdminViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}