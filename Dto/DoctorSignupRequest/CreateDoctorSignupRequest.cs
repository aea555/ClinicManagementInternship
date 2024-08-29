using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.DoctorSignupRequest
{
    public class CreateDoctorSignupRequest : GenericDTO
    {
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required DateTime SubmissionDate { get; set; }
    }
}
