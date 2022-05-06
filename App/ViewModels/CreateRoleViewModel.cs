using System.ComponentModel.DataAnnotations;

namespace App.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}