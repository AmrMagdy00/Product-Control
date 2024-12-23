using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Product_Control.Models;

namespace Product_Control.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }




        public DbSet<Product> Products { get; set; }

        public DbSet<NewProducts> NewProducts { get; set; }

        public DbSet <UpdatedProducts> UpdateProducts { get; set; }

    }
}
