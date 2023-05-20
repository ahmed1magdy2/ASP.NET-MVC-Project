using Microsoft.EntityFrameworkCore;
using Harbor.Models;

namespace Harbor.Data
{
    public class mvcContext : DbContext
    {
        public mvcContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        
        
    }

}
