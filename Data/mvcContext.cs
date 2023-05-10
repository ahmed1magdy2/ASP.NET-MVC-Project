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
        public DbSet<Ships> Ships { get; set; }
        public DbSet<Ports> Ports { get; set; }
        public DbSet<Berths> Berths { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        
    }

}
