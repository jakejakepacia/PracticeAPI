using Microsoft.EntityFrameworkCore;
using PracticeAPI.Models.Entities;

namespace PracticeAPI.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) :base(options)
        {
            
        }

        public DbSet<User> userAccount { get; set; }
    }
}
