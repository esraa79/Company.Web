using System.ComponentModel.DataAnnotations;

namespace Company.Web.Models
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage ="First Name is Required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is Required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is Required")]
        [EmailAddress(ErrorMessage = "Invalid Format")]
        public string  Email { get; set; }

        [Required(ErrorMessage ="Password is required")]
        [RegularExpression(@"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[\W_]).{6,}$",ErrorMessage ="Invalid format")]
        public string Password { get; set; }

        [Required(ErrorMessage = "ConfirmPassword is required")]
        [Compare(nameof(Password),ErrorMessage ="ConfirmPassword doesn't match password")]
        public string ConfirmPassword   { get; set; }

        [Required(ErrorMessage = "IsAgree is required")]
        public bool IsAgree { get; set; }
    }
}
