using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.ViewModel
{
    public class CustomerInfoVM
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must contain only letters and spaces.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        public int GenderId { get; set; }
        [Required]  // Ensures the field is not empty
        public int StateId { get; set; }
        [Required]  // Ensures the field is not empty
        public int DistrictId { get; set; }
       
        public string? GenderName { get; set; }
        public string? StateName { get; set; }
        public string? DistrictName { get; set; }
    

    }
}
