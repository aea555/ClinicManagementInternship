using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Doctor
{
    public class DoctorService(IGenericRepository<Models.Doctor> repository) : GenericService<CreateDoctor, UpdateDoctor, Models.Doctor>(repository), IDoctorService
    {
    }
}
