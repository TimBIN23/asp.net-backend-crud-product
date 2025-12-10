using Microsoft.EntityFrameworkCore;

namespace backend.Models
{
    public class UsmDb : DbContext
    {
        public UsmDb(DbContextOptions<UsmDb> options) : base(options)
        {
        }

        // Example table — add your own DbSets here
        // public DbSet<User> Users { get; set; }
        public DbSet<Todo> Todos { get; set; }
        public DbSet<Product> Products { get; set; }


    }
}
