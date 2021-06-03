using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiModelValidationDemo.Models
{
    public class Employee : IValidatableObject
    {
        [Required]
        [StringLength(maximumLength: 250, MinimumLength = 10)]
        public string Name { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [EmailAddress(ErrorMessage = "Email address is not valid.")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Phone is not valid.")]
        public string Phone { get; set; }

        [Range(minimum: 50, maximum: 400,
            ErrorMessage = "Hourly salary does not fall within allowed range.")]
        [MinLegalSalaryRequired(minJuniorSalary: 50, minSeniorSalary: 200)]
        public double HourlySalary { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var minAllowedBirthDate = DateTime.Today.AddYears(-65);
            if (minAllowedBirthDate > DateOfBirth)
            {
                yield return new ValidationResult("Birthdate is not valid.");
            }
        }
    }

    public class MinLegalSalaryRequiredAttribute : ValidationAttribute
    {
        public MinLegalSalaryRequiredAttribute(double minJuniorSalary, double minSeniorSalary)
        {
            MinJuniorSalary = minJuniorSalary;
            MinSeniorSalary = minSeniorSalary;
        }

        public double MinJuniorSalary { get; }
        public double MinSeniorSalary { get; }
        public string GetErrorMessage() => $"Minimum hourly salary is not valid.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var employee = (Employee)validationContext.ObjectInstance;
            var dateBeforeThirtyYears = DateTime.Today.AddYears(-30);
            var isOlderThanThirdyYears = employee.DateOfBirth <= dateBeforeThirtyYears;
            var hourlySalary = (double)value;

            var isValidSalary = isOlderThanThirdyYears
                ? hourlySalary >= MinSeniorSalary
                : hourlySalary >= MinJuniorSalary;

            return isValidSalary
                ? ValidationResult.Success
                : new ValidationResult(GetErrorMessage());
        }
    }
}
