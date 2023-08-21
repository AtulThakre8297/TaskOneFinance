using System.ComponentModel.DataAnnotations;

namespace Product.UI.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [MaxLength(12, ErrorMessage = "Password must be max 12 characters long.")]
        [MinLength(6, ErrorMessage = "Password must be at least 6 characters long.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
