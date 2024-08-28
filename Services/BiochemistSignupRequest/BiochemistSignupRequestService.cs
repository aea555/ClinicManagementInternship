using ClinicManagementInternship.Dto.BiochemistSignupRequest;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.BiochemistSignupRequest
{
    public class BiochemistSignupRequestService(IGenericRepository<Models.BiochemistSignupRequest> repository) : GenericService<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, Models.BiochemistSignupRequest>(repository), IBiochemistSignupRequestService
    {
    }
}
