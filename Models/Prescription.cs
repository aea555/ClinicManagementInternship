namespace ClinicManagementInternship.Models
{
    public class Prescription : ModelBase
    {
        public required int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public required int DurationDays { get; set; }
        public string? Notes { get; set; }
    }
}
