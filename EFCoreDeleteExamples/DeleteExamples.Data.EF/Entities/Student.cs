using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteExamples.Data.EF.Entities
{
    public class Student
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey(nameof(Teacher))]
        public int TeacherId { get; set; }
        
        public Teacher Teacher { get; set; }

        public override string ToString()
        {
            return $"{{ Id: {Id}, Name: {Name} }}";
        }
    }
}
