using System.ComponentModel.DataAnnotations;

namespace TaskOneFinance.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = " Enter Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string Confirmpassword { get; set; }

        [Required(ErrorMessage = " Enter Email ")]
        [Display(Name = "Email")]
        public string Email { get; set; }


        [Required(ErrorMessage ="Enter Address")]
        public string Address { get; set; }

    }
}
