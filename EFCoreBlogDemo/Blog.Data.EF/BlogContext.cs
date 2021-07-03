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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Post>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Post>()
                .Property(b => b.LastModifiedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Post>()
                .Property(b => b.PublishedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(b => b.LastModifiedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Category>()
                .Property(b => b.PublishedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Tag>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Tag>()
                .Property(b => b.LastModifiedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Tag>()
                .Property(b => b.PublishedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>()
                .Property(b => b.CreatedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>()
                .Property(b => b.LastModifiedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Comment>()
                .Property(b => b.PublishedOn)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
               .Property(u => u.Version)
               .IsRowVersion();
        }

        public DbSet<Post> Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<PostCategories> PostCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<PostTags> PostTags { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
