using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Doctor
{
    public interface IDoctorService : IGenericService<CreateDoctor, UpdateDoctor, Models.Doctor>
    {
    }
}
