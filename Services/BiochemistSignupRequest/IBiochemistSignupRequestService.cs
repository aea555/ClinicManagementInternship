using ClinicManagementInternship.Dto.BiochemistSignupRequest;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.BiochemistSignupRequest
{
    public interface IBiochemistSignupRequestService : IGenericService<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, Models.BiochemistSignupRequest>
    {
    }
}
