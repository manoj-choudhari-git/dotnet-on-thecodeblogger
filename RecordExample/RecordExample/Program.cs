using System;

using static RecordExample.Program;

namespace RecordExample
{
    public abstract record Person(string FirstName, string LastName);

    public record Employee(string EmployeeId, string FirstName, string LastName)
        : Person(FirstName, LastName);

    public abstract class PersonClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class EmployeeClass : PersonClass
    {
        public string EmployeeId { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            // -------------------------------------------------------------
            // Cannot create instance of abstract record.
            // Hence below line would not work.
            // -------------------------------------------------------------
            // var p = new Person("firstName", "lastName");

            // -------------------------------------------------------------
            // RECORDS - Equality Comaprison
            // -------------------------------------------------------------
            var firstRecord = new Employee("EMP_ID_1", "John", "Doe");
            var secondRecord = new Employee("EMP_ID_1", "John", "Doe");

            var compareResult = firstRecord == secondRecord ? "ARE EQUAL" : "ARE NOT EQUAL";
            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            Console.WriteLine($"RECORD-1 : {firstRecord.ToString()}");
            Console.WriteLine($"RECORD-2 : {secondRecord.ToString()}");
            Console.WriteLine($"RECORDS: {compareResult}");
            Console.WriteLine();
            // -------------------------------------------------------------
            // Classes - Equality Comaprison
            // -------------------------------------------------------------
            var firstObj = new EmployeeClass()
            {
                EmployeeId = "EMP_ID_1",
                FirstName = "John",
                LastName = "Doe"
            };
            var secondObj = new EmployeeClass()
            {
                EmployeeId = "EMP_ID_1",
                FirstName = "John",
                LastName = "Doe"
            };

            Console.WriteLine("----------------------------------------------------");
            Console.WriteLine();
            var classComparison = firstObj == secondObj ? "ARE EQUAL" : "ARE NOT EQUAL";
            Console.WriteLine($"Object-1 : {firstObj.ToString()}");
            Console.WriteLine($"Object-2 : {secondObj.ToString()}");
            Console.WriteLine($"Classes: {classComparison }");
            Console.WriteLine();
            Console.WriteLine("----------------------------------------------------");
        }
    }
}