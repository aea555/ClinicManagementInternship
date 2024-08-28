using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.BiochemistSignupRequest
{
    public class UpdateBiochemistSignupRequest : GenericUpdateDTO
    {
        public required SignUpRequestStatus SignUpRequest { get; set; }
    }
}
