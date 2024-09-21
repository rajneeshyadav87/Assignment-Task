using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Assignment_Task.Models
{
    public class Customer_Info
    {
        [Key]
        public int CustomerId { get; set; }
        [MaxLength(100)]
        public string  Name { get; set; }
        public int GenderId { get; set; }
        [ForeignKey("GenderId")]
        public virtual Gender Gender { get; set; }
        public int DistrictId { get; set; }
        [ForeignKey("DistrictId")]
        public virtual DistrictMaster DistrictMaster { get; set; }
   
    }
}
