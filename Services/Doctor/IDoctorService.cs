using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Doctor
{
    public interface IDoctorService : IGenericService<CreateDoctor, UpdateDoctor, Models.Doctor>
    {
        Task<ServiceResult<Models.Doctor>> UpdateDoctorName(int id, string FirstName, string LastName);
    }
}
