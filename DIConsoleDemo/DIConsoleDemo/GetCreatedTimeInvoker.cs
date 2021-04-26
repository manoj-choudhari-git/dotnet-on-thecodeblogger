using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIConsoleDemo
{
    class GetCreatedTimeInvoker
    {
        private readonly ISingletonGetCreatedTime singleton;
        private readonly IScopedGetCreatedTime scoped;
        private readonly ITransientGetCreatedTime transient;

        public GetCreatedTimeInvoker(ISingletonGetCreatedTime singleton, 
            IScopedGetCreatedTime scoped, ITransientGetCreatedTime transient)
        {
            this.singleton = singleton;
            this.scoped = scoped;
            this.transient = transient;
        }

        public void Invoke()
        {
            Console.WriteLine($"Singleton Response: {singleton.GetCreatedTime():MM/dd/yyyy hh:mm:ss.fff tt}, Stays the same.");
            Console.WriteLine($"Scoped Response: {scoped.GetCreatedTime():MM/dd/yyyy hh:mm:ss.fff tt}, Changes only if scope is changed");
            Console.WriteLine($"Transient Response: {transient.GetCreatedTime():MM/dd/yyyy hh:mm:ss.fff tt}, Changes everytime this method is invoked");
        }
    }
}
