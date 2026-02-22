using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=localhost,1433;Initial Catalog=AzureDemoApp;User ID=sa;Password=YourStrong!Password;TrustServerCertificate=True;Encrypt=False;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}