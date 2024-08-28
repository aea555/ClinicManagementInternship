using ClinicManagementInternship.Dto.DoctorSignupRequest;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.DoctorSignupRequest
{
    public class DoctorSignupRequestService(IGenericRepository<Models.DoctorSignupRequest> repository) : GenericService<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, Models.DoctorSignupRequest>(repository), IDoctorSignupRequestService
    {
    }
}
