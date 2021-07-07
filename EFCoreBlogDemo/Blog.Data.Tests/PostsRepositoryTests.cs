using System;
using System.Threading.Tasks;

using Blog.Data.EF;
using Blog.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

using Xunit;

namespace Blog.Data.Tests
{
    public class PostsRepositoryTests
    {
        public readonly DbContextOptions<BlogContext> dbContextOptions;

        public PostsRepositoryTests()
        {
            dbContextOptions = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "MyBlogDb")
                .Options;

        }

        [Fact]
        public async Task WhenPostIsSavedThenItShouldInsertNewEntry()
        {
            var blogContext = new BlogContext(dbContextOptions);
            PostsRepository repository = new PostsRepository(blogContext);
            var newPost = new Post()
            {
                Id = 0,
                Title = "This is Post Title",
                Summary = "This is summary",
                PostContents = "This represents contents of the post",
                Slug = "some-slug",
                IsPublished = true
            };

            await repository.CreateAsync(newPost);
            Assert.Equal(1, await blogContext.Posts.CountAsync());
        }
    }
}
