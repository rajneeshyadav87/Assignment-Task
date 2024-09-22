using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.ViewModel
{
    public class CustomerInfoVM
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Please enter Name.")]
        [RegularExpression(@"^[a-zA-Z\s]*$", ErrorMessage = "Name must contain only letters and spaces.")]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required(ErrorMessage ="Please Select Gender.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numeric values are allowed.")]
        public int GenderId { get; set; }
       
        [Required(ErrorMessage = "Please Select State.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numeric values are allowed.")]
        public int StateId { get; set; }
        [Required(ErrorMessage = "Please Select District.")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Only numeric values are allowed.")]
        public int DistrictId { get; set; }
       
        public string? GenderName { get; set; }
        public string? StateName { get; set; }
        public string? DistrictName { get; set; }
    

    }
}
