using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.DoctorSignupRequest
{
    public class UpdateDoctorSignupRequest : GenericUpdateDTO
    {
        public required SignUpRequestStatus SignUpRequest { get; set; }
    }
}
