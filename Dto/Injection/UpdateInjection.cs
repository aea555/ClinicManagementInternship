using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Injection
{
    public class UpdateInjection : GenericUpdateDTO
    {
        [ValidEntityId<Models.Patient>("Patients", isRequired: false)]
        public int? PatientId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors", isRequired: false)]
        public int? DoctorId { get; set; }
        [ValidEntityId<Models.Drug>("Drugs", isRequired: false)]
        public int? DrugId { get; set; }
    }
}
