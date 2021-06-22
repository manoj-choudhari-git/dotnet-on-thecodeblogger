using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace University.Data.EF.Models
{
    public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            // Specify Table name and Schema
            builder.ToTable("Students", "dbo");

            // Specify primary key 
            // Primary key constraint name is also specified
            builder.HasKey(x => x.Id)
                .HasName("PK_Student");

            // -------------------------------------------
            // Composite Primary Key
            // -------------------------------------------
            // builder
            //    .HasKey(x => new { x.Id, x.FirstName});

            // Required and MaxLength
            builder.Property(x => x.FirstName)
                .HasMaxLength(50)
                .HasColumnName("FName")
                .IsRequired();

            // Required and MaxLength
            builder.Property(x => x.LastName)
                .HasMaxLength(50)
                .HasColumnName("LName")
                .HasDefaultValue("Not Mentioned")
                .IsRequired();

            // Optional with default value
            builder.Property(x => x.Address)
                .IsRequired(required: false);

            // Default Value for date
            builder.Property(x => x.CreatedOn)
                .HasDefaultValueSql("getdate()");
        }
    }
}
