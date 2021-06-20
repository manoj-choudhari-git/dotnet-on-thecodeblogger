using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace University.Data.EF.Models
{

    public class DesignTimeUniversityContextFactory : IDesignTimeDbContextFactory<UniversityContext>
    {
        public UniversityContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<UniversityContext>();

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University; Integrated Security=True;";

            dbContextBuilder.UseSqlServer(connectionString);

            return new UniversityContext(dbContextBuilder.Options);
        }
    }
}
