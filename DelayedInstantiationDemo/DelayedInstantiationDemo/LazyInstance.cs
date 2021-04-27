using System;

using Microsoft.Extensions.DependencyInjection;

namespace DelayedInstantiationDemo
{
    public class LazyInstance<T>: Lazy<T>
    {
        public LazyInstance(IServiceProvider serviceProvider)
            : base(() => serviceProvider.GetRequiredService<T>())
        {

        }
    }
}
