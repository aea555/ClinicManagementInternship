using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Appointment
{
    public class CreateAppointment : GenericDTO
    {
        [ValidEntityId<Models.Clinic>("Clinics")]
        public required int ClinicId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors")]
        public required int DoctorId { get; set; }
        [ValidEntityId<Models.Patient>("Patients")]
        public required int PatientId { get; set; }
        public required DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string? Notes { get; set; }
    }
}
