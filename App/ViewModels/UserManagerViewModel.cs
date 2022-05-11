using System.ComponentModel.DataAnnotations;
using App.Models;

namespace App.ViewModels
{
    public class UserManagerViewModel
    {
        [Required]
        public List<ApplicationUser> UserList { get; set; }
    }
}