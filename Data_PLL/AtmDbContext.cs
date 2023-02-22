using Data_PLL.Entities;
using Microsoft.EntityFrameworkCore;


namespace Data_PLL
{
    public class AtmDbContext : DbContext
    {
        public AtmDbContext(DbContextOptions<AtmDbContext> options)
            : base(options)
        {

        }
        
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<TransactionHistory> TransactionHistories { get; set; }
    }
}
