using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.Models
{
    public class AppUser : IdentityUser
    {
        [Required]
        [StringLength(100)]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        [StringLength(10)]
        public string DomainName { get; set; }
    }
}
