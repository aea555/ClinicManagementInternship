using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Feedback
{
    public class CreateFeedback : GenericDTO
    {
        [ValidEntityId<Models.Patient>("Patients")]
        public required int PatientId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors")]
        public required int DoctorId { get; set; }
        [ValidEntityId<Models.Appointment>("Appointments")]
        public required int AppointmentId { get; set; }
        public required int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
