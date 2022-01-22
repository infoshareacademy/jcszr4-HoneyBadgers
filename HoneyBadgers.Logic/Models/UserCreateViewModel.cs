using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HoneyBadgers.Logic.Models
{
    public class UserCreateViewModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; }
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
        [DisplayName("User Role")]
        public string Role { get; set; }
    }
}
