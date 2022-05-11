using System.ComponentModel.DataAnnotations;
using App.Models;

namespace App.ViewModels
{
    public class AddAdmin
    {
        [Required]
        public string RoleName { get; set; }
        [Required]
        public string Email { get; set; }

        public IList<ApplicationUser> UserList { get; set; }
    }
}