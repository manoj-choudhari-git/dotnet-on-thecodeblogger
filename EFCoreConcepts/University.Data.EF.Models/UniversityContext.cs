using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

namespace University.Data.EF.Models
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Method 1 - Call configure method
            // var studentConfigurations = new StudentEntityTypeConfiguration();
            // studentConfigurations.Configure(modelBuilder.Entity<Student>());
            
            //// Method 2 - ApplyConfiguration method
            // modelBuilder.ApplyConfiguration(studentConfigurations);

            // Method 3 - Apply all from an assembly
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UniversityContext).Assembly);
        }

        public DbSet<Student> Students { get; set; }
    }


    
}
