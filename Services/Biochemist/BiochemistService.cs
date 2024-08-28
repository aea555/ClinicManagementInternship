using ClinicManagementInternship.Dto.Biochemist;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Biochemist
{
    public class BiochemistService(IGenericRepository<Models.Biochemist> repository) : GenericService<CreateBiochemist, UpdateBiochemist, Models.Biochemist>(repository), IBiochemistService
    {
    }
}
