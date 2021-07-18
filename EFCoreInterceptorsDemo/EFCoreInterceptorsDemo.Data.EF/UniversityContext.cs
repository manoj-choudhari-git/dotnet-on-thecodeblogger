
using Microsoft.EntityFrameworkCore;

namespace EFCoreInterceptorsDemo.Data.EF
{
    public class UniversityContext : DbContext
    {
        public UniversityContext(DbContextOptions<UniversityContext> options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // ALERT - DEMO CODE
            // You may want to inject the interceptors into the context 
            optionsBuilder.AddInterceptors(new DemoDbCommandInterceptor());
        }

        public DbSet<Student> Students { get; set; }
    }
}
