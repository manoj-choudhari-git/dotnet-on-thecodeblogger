
using System;

using Microsoft.EntityFrameworkCore;

namespace EFCoreFunctionsDemo.Data.EF
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var methodInfo = typeof(UniversityContext)
                   .GetMethod(nameof(GetStudentsCountWithSameLastName), new[] { typeof(string) });

            modelBuilder.HasDbFunction(methodInfo)
                        .HasName("GetStudentsCountWithSameLastName");
        }

        // CLR Method which would be mapped to Function
        // Ensure that signature of method is same as of Function
        // Do not worry about name of C# method.
        // C# method name would be mapped to SQL Function name in OnModelCreating
        public int GetStudentsCountWithSameLastName(string lastName)
        {
            throw new NotImplementedException();
        }

        public DbSet<Student> Students { get; set; }
    }
}
