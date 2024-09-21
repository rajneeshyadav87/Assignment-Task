using Assignment_Task.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment_Task.Data
{
    public class AppDBContext :IdentityDbContext<AppUser>
    {
        public AppDBContext(DbContextOptions<AppDBContext> option) : base(option)
        {
                
        }
        public DbSet<Customer_Info> Customer_Info { get; set; }
        public DbSet<Gender> Gender { get; set; }
        public DbSet<StateMaster> StateMaster { get; set; }
        public DbSet<DistrictMaster> DistrictMaster { get; set; }
    }
}
