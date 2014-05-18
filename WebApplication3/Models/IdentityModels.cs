using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace WebApplication3.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<Street> Cities { get; set; }
    }

    public class Street
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string City { get; set; }
    }
}