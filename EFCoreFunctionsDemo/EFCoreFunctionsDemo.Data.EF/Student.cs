using System;

namespace EFCoreFunctionsDemo.Data.EF
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public DateTime DeletedOn { get; set; }

        public override string ToString()
        => $"{{ Id: {Id}, FirstName={FirstName}, LastName:{LastName} }}";
    }
}
