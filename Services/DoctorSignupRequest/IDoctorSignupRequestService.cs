using ClinicManagementInternship.Dto.DoctorSignupRequest;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.DoctorSignupRequest
{
    public interface IDoctorSignupRequestService : IGenericService<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, Models.DoctorSignupRequest>
    {
    }
}
