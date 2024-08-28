using ClinicManagementInternship.Dto.Clinic;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Clinic
{
    public interface IClinicService : IGenericService<CreateClinic, UpdateClinic, Models.Clinic>
    {
    }
}
