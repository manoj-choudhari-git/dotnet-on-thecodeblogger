using System;

using Blog.Data.EF.Entities;

using Microsoft.EntityFrameworkCore;

namespace Blog.Data.EF
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Post> Categories { get; set; }
        public DbSet<PostCategories> PostCategories { get; set; }
        public DbSet<Post> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Post> Comments { get; set; }
    }
}
