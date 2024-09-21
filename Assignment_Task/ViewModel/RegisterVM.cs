using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).{8,}$", ErrorMessage = "Password must be at least 8 characters long and contain at least one uppercase letter, one lowercase letter, one digit, and one non-alphanumeric character.")]
        public string Password { get; set; }
        [Compare("Password",ErrorMessage ="Password don't match.")]
        [Display(Name = "Cunfirm Password")]
        public string CunfirmPassword { get; set; }
        [Required]
        [Display(Name = "Domain Name")]
        [RegularExpression(@"^[a-zA-Z0-9_]{1,10}$", ErrorMessage = "DomainName must be alphanumeric (with underscores) and up to 10 characters.")]
        public string DomainName { get; set; }

    }
}
