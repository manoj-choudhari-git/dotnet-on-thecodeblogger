using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParametersDemo
{
    public class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"{{ Age: {Age}, Name: {Name} }}";
        }
    }

    public class ReferenceTypeDemo
    {
        public void Execute()
        {
            Person p = new Person();
            p.Age = 25;
            p.Name = "Sachin Tendulkar";

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Inside Caller: Before ChangeDetails : Value: {p}");
            ChangeDetails(p);
            Console.WriteLine($"Inside Caller: After ChangeDetails : Value: {p}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Inside Caller: Before ChangeObject : Value: {p}");
            ChangeObject(p);
            Console.WriteLine($"Inside Caller: After ChangeObject : Value: {p}");

            Console.WriteLine("----------------------------------------------------------------");
            Console.WriteLine($"Inside Caller: Before ChangeObjectByRef : Value: {p}");
            ChangeObjectByRef(ref p);
            Console.WriteLine($"Inside Caller: After ChangeObjectByRef : Value: {p}");

        }

        private void ChangeDetails(Person p)
        {
            p.Age = p.Age + 10;
            p.Name = "Rahul Dravid";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Inside ChangeDetails: Value: {p}");
            Console.ResetColor();
        }

        private void ChangeObject(Person p)
        {
            p = new Person();
            p.Age = 20;
            p.Name = "MS Dhoni";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Inside ChangeObject: Value: {p}");
            Console.ResetColor();
        }

        private void ChangeObjectByRef(ref Person p)
        {
            p = new Person();
            p.Age = 20;
            p.Name = "MS Dhoni";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Inside ChangeObject: Value: {p}");
            Console.ResetColor();
        }
    }
}
