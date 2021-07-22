using System;

namespace EFCoreGlobalFiltersDemo.Data.EF
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string Nationality { get; set; }

        public DateTime CreatedOn { get; set; }
        
        public DateTime ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime DeletedOn { get; set; }

        public override string ToString()
        => $"{{ Id: {Id}, FirstName={FirstName}, LastName:{LastName}, IsDeleted={IsDeleted} }}";
    }
}
