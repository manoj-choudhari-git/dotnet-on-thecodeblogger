using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EFCoreFunctionsDemo.Data.EF
{

    public class DesignTimeUniversityContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            var dbContextBuilder = new DbContextOptionsBuilder<UniversityContext>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University; Integrated Security=True;";
            dbContextBuilder.UseSqlServer(connectionString);
            return new UniversityContext(dbContextBuilder.Options);
        }
    }
}
