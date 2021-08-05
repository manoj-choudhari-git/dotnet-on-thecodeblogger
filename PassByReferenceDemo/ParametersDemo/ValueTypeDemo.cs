using System;

namespace ParametersDemo
{
    public class ValueTypeDemo
    {
        public void Execute()
        {
            int value = 9;

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Inside Caller: Before ProcessByValue : Value: {value}");
            ProcessByValue(value);
            Console.WriteLine($"Inside Caller: After ProcessByValue : Value: {value}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Inside Caller: Before ProcessByReference : Value: {value}");
            ProcessByReference(ref value);
            Console.WriteLine($"Inside Caller: After ProcessByReference : Value: {value}");
            Console.WriteLine("----------------------------------------------------------------");
        }

        private void ProcessByValue(int value)
        {
            value = value * 2 + 1;
            Console.WriteLine($"Inside ProcessByValue: Current Value: {value}");
        }

        private void ProcessByReference(ref int value)
        {
            value = value * 2 + 1;
            Console.WriteLine($"Inside ProcessByReference: Current Value: {value}");
        }
    }
}
