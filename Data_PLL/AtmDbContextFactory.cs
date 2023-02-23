using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data_PLL
{
    public class AtmDbContextFactory : IDesignTimeDbContextFactory<AtmDbContext>
    {
        public AtmDbContextFactory()
        {

        }

        public AtmDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AtmDbContext>();

            string ConnectionString = @"Data Source=LAPTOP-AI62M7MS\SQLEXPRESS;Initial Catalog=EFCoreAtmAppDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            optionsBuilder.UseSqlServer(ConnectionString);

            return new AtmDbContext(optionsBuilder.Options);
        }
    }
}
