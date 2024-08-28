using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Utils
{
    public class ValidEntityIdAttribute<T>(string entitySetName) : ValidationAttribute where T : class
    {
        private readonly string _entitySetName = entitySetName;

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null || value is not int id)
            {
                return new ValidationResult("Id is required and must be an integer.");
            }

            var dbContext = validationContext.GetService(typeof(DbContext)) as DbContext;
            var entitySet = dbContext.Set<T>();
            var entityExists = entitySet.Any(e => EF.Property<int>(e, "Id") == id);

            if (!entityExists)
            {
                return new ValidationResult($"Entity with Id {id} does not exist in {_entitySetName}.");
            }

            return ValidationResult.Success;
        }
    }
}
