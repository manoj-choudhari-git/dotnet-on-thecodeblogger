using System.Linq;
using System.Threading.Tasks;

using EventsDemo.Data.EF;

using Microsoft.EntityFrameworkCore;

namespace EventsDemoConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // First Unit-of-Work showing Add operation
            AddStudents();

            // Second Unit-of-Work showing Update and Remove operations
            await ModifyStudents();
        }

        static void AddStudents()
        {
            using var context = BuildUniversityContext();
            context.Add(
                new Student
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Address = "4 Privet Drive",
                });

            context.Add(
                new Student
                {
                    FirstName = "Jane",
                    LastName = "Doe",
                    Address = "4 Privet Drive",
                });
            context.SaveChanges();
        }

        static async Task ModifyStudents()
        {
            using var context = BuildUniversityContext();
            var student = await context.Students.Where(x => x.Id == 1).FirstOrDefaultAsync();
            student.FirstName = "Harry";
            student.LastName = "Potter";
            context.Update(student);

            var anotherStudent = await context.Students.Where(x => x.FirstName == "Jane").FirstOrDefaultAsync();
            context.Remove(anotherStudent);
            await context.SaveChangesAsync();
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
