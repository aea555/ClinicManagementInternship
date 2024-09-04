using ClinicManagementInternship.Enums;

namespace ClinicManagementInternship.Models
{
    public class Appointment : ModelBase
    {
        public required int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public required int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; } = AppointmentStatus.APPROVED;
        public required DateTime StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string? Notes { get; set; }
    }
}
