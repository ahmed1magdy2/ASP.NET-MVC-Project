using Microsoft.EntityFrameworkCore;
using asp.net_project.Models;

namespace asp.net_project.Data
{
    public class mvcContext : DbContext
    {
        public mvcContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Ships> Ships { get; set; } 
        public DbSet<Berths> Berths { get; set; }
        public DbSet<Cargo> Cargoes { get; set; }
        public DbSet<Transactions> Transactions { get; set; }
        public DbSet<Invoices> Invoices { get; set; }

        
    }

}
