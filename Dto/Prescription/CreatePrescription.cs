using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Prescription
{
    public class CreatePrescription : GenericDTO
    {
        [ValidEntityId<Models.Doctor>("Doctors")]
        public required int DoctorId { get; set; }
        [ValidEntityId<Models.Patient>("Patients")]
        public required int PatientId { get; set; }
        [ValidEntityId<Models.Appointment>("Appointments")]
        public required int AppointmentId { get; set; }
        public required DateTime Date { get; set; }
        public required int DurationDays { get; set; }
        public string? Notes { get; set; }
    }
}
