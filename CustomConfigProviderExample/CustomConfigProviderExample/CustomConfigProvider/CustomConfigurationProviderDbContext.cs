
using Microsoft.EntityFrameworkCore;

namespace CustomConfigProviderExample.CustomConfigProvider
{
    public class CustomConfigurationProviderDbContext: DbContext
    {
        public CustomConfigurationProviderDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ConfigurationSetting> ConfigurationSetting { get; set; }
    }
}
