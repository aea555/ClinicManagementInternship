using ClinicManagementInternship.Data;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Utils
{
    public class UniqueAccountIdValidation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is null || !(value is int accountId)) return new ValidationResult("AccountId is required and must be an integer.");

            if (validationContext.GetService(typeof(DataContext)) is not DataContext dbContext) return new ValidationResult("Unable to access the database context. Make sure DbContext is correctly registered.");

            var isAccountIdUsed = dbContext.Doctors.Any(d => d.AccountId == accountId) ||
                                  dbContext.Patients.Any(p => p.AccountId == accountId) ||
                                  dbContext.Biochemists.Any(b => b.AccountId == accountId) ||
                                  dbContext.Admins.Any(a => a.AccountId == accountId);

            if (isAccountIdUsed) return new ValidationResult($"AccountId {accountId} is already in use.");

            return ValidationResult.Success;
        }
    }
}
