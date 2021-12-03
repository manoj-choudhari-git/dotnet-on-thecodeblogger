using DeleteExamples.Data.EF;
using DeleteExamples.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeleteExamples
{
    public class OneToManyHelper
    {
        public static void SeedData(UniversityContext context)
        {
            var teachers = new List<Teacher>()
            {
                new Teacher()
                {
                    Name = "Teacher 1",
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Student 1"},
                        new Student() { Name = "Student 2"}
                    }
                },
                new Teacher()
                {
                    Name = "Teacher 2",
                    Students = new List<Student>()
                    {
                        new Student() { Name = "Student 3"},
                        new Student() { Name = "Student 4"}
                    }
                }
            };

            context.Teachers.AddRange(teachers);
            context.SaveChanges();
        }

        public static async Task Delete(UniversityContext context)
        {
            var teachers = await context.Teachers.Include(x => x.Students).ToListAsync();
            context.Teachers.Remove(teachers[0]);
            await context.SaveChangesAsync();
        }
    }
}
