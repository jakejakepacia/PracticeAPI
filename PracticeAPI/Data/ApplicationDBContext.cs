using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models.Entities;

namespace PracticeAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<User> UserAccount { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
