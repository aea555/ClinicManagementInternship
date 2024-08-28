using ClinicManagementInternship.Dto.Clinic;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Clinic
{
    public class ClinicService(IGenericRepository<Models.Clinic> repository) : GenericService<CreateClinic, UpdateClinic, Models.Clinic>(repository), IClinicService
    {
    }
}
