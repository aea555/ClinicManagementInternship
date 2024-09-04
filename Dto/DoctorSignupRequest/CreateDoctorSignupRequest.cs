using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.DoctorSignupRequest
{
    public class CreateDoctorSignupRequest : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
