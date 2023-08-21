using System.ComponentModel.DataAnnotations;

namespace TaskOneFinance.Models
{
    public class RegisterDTO
    {
        [MaxLength(100),Required(ErrorMessage = "Enter Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [DataType(DataType.Password)]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters.")]
        public string Password { get; set; }

        [Required(ErrorMessage = " Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }


        [MaxLength(100),Required(ErrorMessage = "Enter Address")]

        public string Address { get; set; }
    }
}
