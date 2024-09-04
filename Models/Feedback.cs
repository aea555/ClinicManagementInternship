namespace ClinicManagementInternship.Models
{
    public class Feedback : ModelBase
    {
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public required int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public required int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
