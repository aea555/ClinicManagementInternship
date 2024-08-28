using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Injection
{
    public class CreateInjection : GenericDTO
    {
        [ValidEntityId<Models.Patient>("Patients")]
        public required int PatientId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors")]
        public required int DoctorId { get; set; }
        [ValidEntityId<Models.Drug>("Drugs")]
        public required int DrugId { get; set; }
    }
}
