using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeleteExamples.Data.EF.Entities
{
    public class Author
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Book Book { get; set; }
    }
}
