using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.BiochemistSignupRequest
{
    public class CreateBiochemistSignupRequest : GenericDTO
    {
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime SubmissionDate { get; set; }
        public SignUpRequestStatus SignUpRequest { get; } = SignUpRequestStatus.PENDING;
    }
}
