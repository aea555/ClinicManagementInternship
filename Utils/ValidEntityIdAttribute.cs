using ClinicManagementInternship.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Utils
{
    public class ValidEntityIdAttribute<T>(string entitySetName, bool isRequired = true) : ValidationAttribute where T : class
    {
        private readonly string _entitySetName = entitySetName;
        private readonly bool _isRequired = isRequired;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // If the value is null and not required, skip validation
            if (!_isRequired && value == null)
                return ValidationResult.Success;

            // If value is required but missing or not an integer, return error
            if (value == null)
            {
                if (_isRequired)
                    return new ValidationResult("Id is required.");

                return ValidationResult.Success; // If not required and value is null, skip validation
            }

            // Check if the value is an integer
            if (value is not int id)
                return new ValidationResult("Id must be an integer.");

            if (validationContext.GetService(typeof(DataContext)) is not DataContext dbContext)
                return new ValidationResult("Unable to access the database context. Make sure DbContext is correctly registered.");

            var entitySet = dbContext.Set<T>();
            var entityExists = entitySet.Any(e => EF.Property<int>(e, "Id") == id);

            if (!entityExists)
                return new ValidationResult($"Entity with Id {id} does not exist.");

            return ValidationResult.Success;
        }
    }
}