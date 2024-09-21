using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.ViewModel
{
    public class LoginVM
    {
        [Required(ErrorMessage = "User name is required.")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
