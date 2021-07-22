using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EFCoreGlobalFiltersDemo.Data.EF;

using Microsoft.EntityFrameworkCore;

namespace EFCoreGlobalFiltersDemo
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // AddStudents();
            await DisplayAllStudents();

            await DisplayStudentsByNationality("Indian");
            await DisplayStudentsByNationality("Australian");
            await DisplayStudentsByNationality("British");

            await DisplayDeletedStudents();

        }

        static void AddStudents()
        {
            using var context = BuildUniversityContext();

            var studentCollection = new List<Student>()
            {
                new Student { FirstName = "MS", LastName = "Dhoni", Nationality = "Indian" },
                new Student { FirstName = "Sachin", LastName = "Tendulkar", Nationality = "Indian" },
                new Student { FirstName = "R", LastName = "Dravid", Nationality = "Indian", IsDeleted = true },
                

                new Student { FirstName = "Ricky", LastName = "Ponting", Nationality = "Australian" },
                new Student { FirstName = "Shane", LastName = "Warne", Nationality = "Australian" },
                new Student { FirstName = "Steve", LastName = "Waugh", Nationality = "Australian", IsDeleted = true },

                new Student { FirstName = "Joe", LastName = "Root", Nationality = "British" },
                new Student { FirstName = "Stuart", LastName = "Broad", Nationality = "British" },
                new Student { FirstName = "Andrew", LastName = "Flintoff", Nationality = "British", IsDeleted = true },

                new Student { FirstName = "AB", LastName = "de Villiers", Nationality = "South African" },
                new Student { FirstName = "Dale", LastName = "Steyn", Nationality = "South African" },
                new Student { FirstName = "Alan", LastName = "Donald", Nationality = "South African", IsDeleted = true },
            };

            context.AddRange(studentCollection);
            context.SaveChanges();
        }

        static async Task DisplayStudentsByNationality(string nationality)
        {
            using var context = BuildUniversityContext();
            var studentCollection = await context.Students
                    .Where(x => x.Nationality == nationality)
                    .ToListAsync();
            Console.WriteLine();
            Console.WriteLine($"Display {nationality} Students: ");
            Display(studentCollection);
        }


        static async Task DisplayAllStudents()
        {
            using var context = BuildUniversityContext();
            var studentCollection = await context.Students.ToListAsync(); ;
            Console.WriteLine();
            Console.WriteLine("Display All Non-Deleted Students");
            Display(studentCollection);
        }

        static async Task DisplayDeletedStudents()
        {
            using var context = BuildUniversityContext();
            var studentCollection = await context.Students.IgnoreQueryFilters().Where(x=> x.IsDeleted).ToListAsync(); ;
            Console.WriteLine();
            Console.WriteLine("Display Deleted Students");
            Display(studentCollection);
        }

        static void Display(List<Student> studentCollection)
        {
            // Print Results
            Console.WriteLine("---------------------------------------");
            foreach (var student in studentCollection)
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
