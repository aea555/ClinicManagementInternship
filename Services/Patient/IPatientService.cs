using ClinicManagementInternship.Dto.Patient;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Patient
{
    public interface IPatientService : IGenericService<CreatePatient, UpdatePatient, Models.Patient>
    {
    }
}
