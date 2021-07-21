using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EFCoreFunctionsDemo.Data.EF;

using Microsoft.EntityFrameworkCore;

namespace EFCoreFunctionsDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // First Unit-of-Work showing Add operation
            AddStudents();

            // Second Unit-of-Work showing Update and Remove operations
            await QueryStudents();
        }

        static void AddStudents()
        {
            using var context = BuildUniversityContext();

            var studentCollection = new List<Student>()
            {
                new Student { FirstName = "John", LastName = "Doe", Address = "4 Privet Drive" },
                new Student { FirstName = "Jane", LastName = "Doe", Address = "6 Privet Drive" },
                new Student { FirstName = "Harry", LastName = "Potter", Address = "8 Privet Drive" },
                new Student { FirstName = "Ginny", LastName = "Weasly", Address = "10 Privet Drive" },
            };

            context.AddRange(studentCollection);
            context.SaveChanges();
        }

        static async Task QueryStudents()
        {
            using var context = BuildUniversityContext();
            
            // Query using the method
            var studentsQuery = from student in context.Students
                where   context.GetStudentsCountWithSameLastName(student.LastName) > 1
                select student;

            // Get Results from Query
            var studentsCollection = await studentsQuery.ToListAsync();

            // Print Results
            Console.WriteLine("---------------------------------------");
            foreach(var student in studentsCollection)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("---------------------------------------");
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
