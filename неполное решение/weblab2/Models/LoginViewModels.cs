using System.ComponentModel.DataAnnotations;

namespace weblab2.Models
{

    public class LoginViewModels
    {
        [Required]
        [Display(Name = "Login")]
        public string UserName { get; set; }

        [Required]
        [UIHint("password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "remember me?")]
        public bool RememberMe { get; set; }
    }
}
