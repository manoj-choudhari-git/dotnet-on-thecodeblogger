using System;

namespace ParametersDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ValueTypeDemo valueTypeDemo = new ValueTypeDemo();
            valueTypeDemo.Execute();

            ReferenceTypeDemo referenceTypeDemo = new ReferenceTypeDemo();
            referenceTypeDemo.Execute();
        }

    }
}
