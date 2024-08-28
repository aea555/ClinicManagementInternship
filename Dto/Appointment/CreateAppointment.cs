using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Appointment
{
    public class CreateAppointment : GenericDTO
    {
        public required int ClinicId { get; set; }
        public required int DoctorId { get; set; }
        public required int PatientId { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime FinishTime { get; set; }
    }
}
