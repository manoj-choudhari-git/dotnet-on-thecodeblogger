using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Data.EF.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        public string FirstName { get; set; }

        public string LastName { get; set; }

        // Data annotation for specifying auto-generated concurrency token
        // Uncomment if you want to use data annotation instead of fluent API
        // [Timestamp]
        public byte[] Version { get; set; }
    }
}
