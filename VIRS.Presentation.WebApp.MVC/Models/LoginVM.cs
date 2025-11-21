using System.ComponentModel.DataAnnotations;

namespace VIRS.Presentation.WebApp.MVC.Models
{
    public class LoginVM
    {
        [Required(ErrorMessage = "نام کاربری الزامی است")]
        public string Username { get; set; }
        [Required(ErrorMessage = "رمز عبور الزامی است")]
        public string Password { get; set; }
    }
}
