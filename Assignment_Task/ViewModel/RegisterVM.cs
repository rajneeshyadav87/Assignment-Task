using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.ViewModel
{
    public class RegisterVM
    {
        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        [Compare("Password",ErrorMessage ="Password don't match.")]
        [Display(Name = "Cunfirm Password")]
        public string? CunfirmPassword { get; set; }
        [Required]
        [Display(Name = "Domain Name")]
        [RegularExpression(@"^[a-zA-Z0-9_]{1,10}$", ErrorMessage = "DomainName must be alphanumeric (with underscores) and up to 10 characters.")]
        public string? DomainName { get; set; }

    }
}
