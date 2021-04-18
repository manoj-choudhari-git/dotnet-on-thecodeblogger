using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CustomConfigProviderExample.CustomConfigProvider
{
    public static class CustomConfigProviderExtensions
    {
        public static IConfigurationBuilder AddCustomDatabaseConfiguration(
            this IConfigurationBuilder builder, Action<DbContextOptionsBuilder> optionsAction)
        {
            return builder.Add(new CustomConfigurationSource(optionsAction));
        }
    }
}
