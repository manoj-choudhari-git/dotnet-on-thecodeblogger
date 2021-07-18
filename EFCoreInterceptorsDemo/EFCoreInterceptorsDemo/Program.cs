using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EFCoreInterceptorsDemo.Data.EF;

using Microsoft.EntityFrameworkCore;

namespace EFCoreInterceptorsDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // First Unit-of-Work showing Add operation
            AddStudents();

            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("With Interceptor....");
            await GetAllStudents(applyInterceptor: true);
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("Without Interceptor....");
            await GetAllStudents(applyInterceptor: false);
            Console.WriteLine("---------------------------------------------");
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

        static async Task GetAllStudents(bool applyInterceptor)
        {
            using var context = BuildUniversityContext();

            IList<Student> studentCollection = null;
            if (applyInterceptor)
            {
                studentCollection = await context.Students.TagWith("Apply OrderBy DESC").ToListAsync();
            }
            else
            {
                studentCollection = await context.Students.ToListAsync();
            }

            Console.WriteLine("Printing List of Students");
            foreach(var student in studentCollection)
            {
                Console.WriteLine(student);
            }
        }

        static UniversityContext BuildUniversityContext()
        {
            var dbContextBuilder = new DbContextOptionsBuilder<UniversityContext>();

            // HARDCODED - For this demo.  In real world apps, this should come from some kind of secrets manager
            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=University; Integrated Security=True;";

            dbContextBuilder.UseSqlServer(connectionString);
            return new UniversityContext(dbContextBuilder.Options);
        }
    }
}
