using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Intro.Models
{
    public class RwadMisrConext:IdentityDbContext<ApplicationUser>
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Department { get; set; }
        public RwadMisrConext()
        {

        }

        public RwadMisrConext(DbContextOptions options ) :base(options) { }
    
    }
}
