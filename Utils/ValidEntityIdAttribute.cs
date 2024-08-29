using ClinicManagementInternship.Data;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Utils
{
    public class ValidEntityIdAttribute<T> : ValidationAttribute where T : class
    {
        private readonly string _entitySetName;

        public ValidEntityIdAttribute(string entitySetName)
        {
            _entitySetName = entitySetName;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null || !(value is int id))
            {
                return new ValidationResult("Id is required and must be an integer.");
            }


            if (validationContext.GetService(typeof(DataContext)) is not DataContext dbContext)
            {
                return new ValidationResult("Unable to access the database context. Make sure DbContext is correctly registered.");
            }

            var entitySet = dbContext.Set<T>();
            var entityExists = entitySet.Any(e => EF.Property<int>(e, "Id") == id);

            if (!entityExists)
            {
                return new ValidationResult($"Entity with Id {id} does not exist.");
            }

            return ValidationResult.Success;
        }
    }
}
