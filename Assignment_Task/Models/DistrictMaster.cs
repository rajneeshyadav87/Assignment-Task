using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;

namespace Assignment_Task.Models
{
    public class DistrictMaster
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        public int StateId { get; set; }
        [ForeignKey("StateId")]
        public virtual StateMaster StateMaster { get; set; }
    }
}
