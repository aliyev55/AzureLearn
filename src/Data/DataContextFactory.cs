using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Data
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseSqlServer("Server=tcp:azurelearnsqlservervusal01.database.windows.net,1433;Initial Catalog=AzureDemoApp;User ID=sqladmin;Password=YourStrong123Password;Persist Security Info=False;MultipleActiveResultSets=True;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}