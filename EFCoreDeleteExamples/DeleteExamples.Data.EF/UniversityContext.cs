
using System;
using System.Linq;
using System.Collections.Generic;
using DeleteExamples.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

namespace DeleteExamples.Data.EF
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<CountryLanguage>()
                .HasKey(t => t.Id);

            modelBuilder
                .Entity<CountryLanguage>()
                .HasOne(c => c.AssociatedCountry)
                .WithMany(c => c.CountryLanguages)
                .HasForeignKey(cl => cl.CountryId);

            modelBuilder
                .Entity<CountryLanguage>()
                .HasOne(l => l.AssociatedLanguage)
                .WithMany(l => l.CountryLanguages)
                .HasForeignKey(cl => cl.LanguageId);

            // By Convention, Cascade Delete is Enabled, even without below code
            // IF the foreign key is NON-NULLABLE.
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Students)
                .WithOne(c => c.Teacher)
                .HasForeignKey(c => c.TeacherId)
                .OnDelete(DeleteBehavior.Cascade);

        }

        // Many to Many Relationship
        public DbSet<Country> Countries { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<CountryLanguage> CountryLanguages { get; set; }

        // One to Many relationship
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Student> Students { get; set; }

        // One to One relationship
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}