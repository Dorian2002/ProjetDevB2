using System.ComponentModel.DataAnnotations;

namespace App.ViewModels {
    public class ProfileRequest {

        [Required]
        public string OldUserName { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name ="Confirm Password")]
        [Compare("NewPassword",ErrorMessage ="Password and confirmation password not match.")]
        public string? ConfirmNewPassword { get; set; }

        [Required]
        public bool ModifiedByAdmin { get; set; }
    }
}