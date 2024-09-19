using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,}$", ErrorMessage = "Invalid format")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare(nameof(Password), ErrorMessage = "ConfirmPassword doesn't match password")]
        public string ConfirmPassword { get; set; }

        public string Email { get; set; }
        public string  Token { get; set; }
    }
}
