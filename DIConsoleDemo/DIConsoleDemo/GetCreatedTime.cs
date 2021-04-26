using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleDemo
{
    public class GetCreatedTimeImplementation : ITransientGetCreatedTime, 
        IScopedGetCreatedTime, 
        ISingletonGetCreatedTime
    {
        private readonly DateTime createdOn;

        public GetCreatedTimeImplementation()
        {
            this.createdOn = DateTime.Now;
        }
        public DateTime GetCreatedTime()
        {
            return this.createdOn.AddHours(-6);
        }
    }
}
