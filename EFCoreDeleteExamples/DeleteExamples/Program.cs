using DeleteExamples.Data.EF;
using DeleteExamples.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeleteExamples
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using var context = BuildUniversityContext();

            ManyToManyHelper.SeedData(context);
            await ManyToManyHelper.Delete(context);

            OneToManyHelper.SeedData(context);
            await OneToManyHelper.Delete(context);

            OneToOneHelper.SeedData(context);
            await OneToOneHelper.Delete(context);
        }
        
        static UniversityContext BuildUniversityContext()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<UniversityContext>();
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University; Integrated Security=True;";
            dbContextBuilder.UseSqlServer(connectionString);
            return new UniversityContext(dbContextBuilder.Options);
        }
    }
}
