
using System;
using System.Reflection.Metadata;

using Microsoft.EntityFrameworkCore;

namespace EFCoreGlobalFiltersDemo.Data.EF
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasQueryFilter(s => !s.IsDeleted);
        }

        public DbSet<Student> Students { get; set; }
    }
}
