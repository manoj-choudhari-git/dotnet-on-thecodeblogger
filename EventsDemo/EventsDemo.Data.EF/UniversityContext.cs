
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EventsDemo.Data.EF
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
            ChangeTracker.Tracked += ChangeTracker_Tracked;
            ChangeTracker.StateChanged += ChangeTracker_StateChanged;
            SavingChanges += UniversityContext_SavingChanges;
            SavedChanges += UniversityContext_SavedChanges;
            SaveChangesFailed += UniversityContext_SaveChangesFailed;
        }

        private void ChangeTracker_StateChanged(object sender, EntityStateChangedEventArgs e)
        {
            // YOU CAN USE AN INTERFACE OR A BASE CLASS
            // But, for this demo, we are directly typecasting to Student model
            var student = e.Entry.Entity as Student;
            switch (e.Entry.State)
            {
                case EntityState.Deleted:
                    student.DeletedOn = DateTime.Now;
                    Console.WriteLine($"Marked for delete: {e.Entry.Entity}");
                    break;
                case EntityState.Modified:
                    student.ModifiedOn = DateTime.Now;
                    Console.WriteLine($"Marked for update: {e.Entry.Entity}");
                    break;
                case EntityState.Added:
                    student.CreatedOn = DateTime.Now;
                    Console.WriteLine($"Marked for insert: {e.Entry.Entity}");
                    break;
            }
        }

        private void ChangeTracker_Tracked(object sender, EntityTrackedEventArgs e)
        {
            Console.WriteLine($"Marked for Tracking: {e.Entry.Entity}");
        }

        private void UniversityContext_SavingChanges(object sender, SavingChangesEventArgs e)
        {
            Console.WriteLine($"Saving Changes at {DateTime.Now}");
        }

        private void UniversityContext_SavedChanges(object sender, SavedChangesEventArgs e)
        {
            Console.WriteLine($"Saved Chagnes at {DateTime.Now}");
        }

        private void UniversityContext_SaveChangesFailed(object sender, SaveChangesFailedEventArgs e)
        {
            Console.WriteLine($"Save Chagnes Failed at {DateTime.Now}");
        }

        public DbSet<Student> Students { get; set; }
    }
}
