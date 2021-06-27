using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;

namespace Blog.Data.EF
{

    public class DesignTimeBlogContextFactory : IDesignTimeDbContextFactory<BlogContext>
    {
        public BlogContext CreateDbContext(string[] args)
        {
            //var configuration = new ConfigurationBuilder()
            //     .SetBasePath(Directory.GetCurrentDirectory())
            //     .AddJsonFile("appsettings.json")
            //     .Build();

            var dbContextBuilder = new DbContextOptionsBuilder<BlogContext>();

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=MyBlogDb; Integrated Security=True;";

            dbContextBuilder.UseSqlServer(connectionString);

            return new BlogContext(dbContextBuilder.Options);
        }
    }
}
