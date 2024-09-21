using System.ComponentModel.DataAnnotations;

namespace Assignment_Task.Models
{
    public class StateMaster
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
    }
}
