using DeleteExamples.Data.EF;
using DeleteExamples.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeleteExamples
{
    public static class OneToOneHelper
    {
        public static void SeedData(UniversityContext context)
        {
            var books = new List<Book>()
            {
                new Book() { Name = "Book_1" },
                new Book() { Name = "Book_2" },
                new Book() { Name = "Book_3" },
            };

            var authors = new List<Author>()
            {
                new Author() { Name = "Author_1", Book = books[0] },
                new Author() { Name = "Author_2", Book = books[1] },
                new Author() { Name = "Author_3", Book = books[2] },
            };

            context.Books.AddRange(books);
            context.Authors.AddRange(authors);
            context.SaveChanges();
        }

        public static async Task Delete(UniversityContext context)
        {
            var books = await context.Books.Include(x => x.Author).ToListAsync();
            context.Books.Remove(books[0]);
            await context.SaveChangesAsync();
        }
    }
}
