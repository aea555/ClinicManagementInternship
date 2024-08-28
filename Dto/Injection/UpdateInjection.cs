using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Injection
{
    public class UpdateInjection : GenericUpdateDTO
    {
        [ValidEntityId<Models.Patient>("Patients")]
        public int? PatientId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors")]
        public int? DoctorId { get; set; }
        [ValidEntityId<Models.Drug>("Drugs")]
        public int? DrugId { get; set; }
    }
}
