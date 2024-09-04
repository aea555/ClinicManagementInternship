using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Patient
{
    public class CreatePatient : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        [UniqueAccountIdValidation]
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
