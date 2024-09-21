using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.Models
{
    public class Gender
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
