using ClinicManagementInternship.Dto.Patient;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Patient
{
    public class PatientService(IGenericRepository<Models.Patient> repository) : GenericService<CreatePatient, UpdatePatient, Models.Patient>(repository), IPatientService
    {
    }
}
