using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomConfigProviderExample.CustomConfigProvider
{
    public class CustomConfigurationProvider : ConfigurationProvider
    {
        public CustomConfigurationProvider(Action<DbContextOptionsBuilder> optionsAction)
        {
            OptionsAction = optionsAction;
        }

        Action<DbContextOptionsBuilder> OptionsAction { get; }

        public override void Load()
        {
            var builder = new DbContextOptionsBuilder<CustomConfigurationProviderDbContext>();
            OptionsAction(builder);

            using var dbContext = new CustomConfigurationProviderDbContext(builder.Options);
            dbContext.Database.EnsureCreated();
            Data = !dbContext.ConfigurationSetting.Any()
                ? CreateAndSaveDefaultValues(dbContext)
                : dbContext.ConfigurationSetting.ToDictionary(c => c.Key, c => c.Value);
        }

        private static IDictionary<string, string> CreateAndSaveDefaultValues(
            CustomConfigurationProviderDbContext dbContext)
        {
            var configValues = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            { 
                { "Mode", "CustomConfigProvider" },
                { "MailFeature:0:Subject", "User account locked." },
                { "MailFeature:1:Subject", "Account Verification Required." }
            };

            dbContext.ConfigurationSetting
                .AddRange(configValues.Select(kvp => new ConfigurationSetting
                {
                    Key = kvp.Key,
                    Value = kvp.Value
                })
                .ToArray());

            dbContext.SaveChanges();
            return configValues;
        }
    }
}
