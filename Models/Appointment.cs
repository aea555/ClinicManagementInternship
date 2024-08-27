using ClinicManagementInternship.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }
        public required int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public required int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public AppointmentStatus AppointmentStatus { get; set; }
        public required DateTime StartTime { get; set; }
        public required DateTime FinishTime { get; set; }
        public required DateTime CompleteTime { get; set; }
        public string? Notes { get; set; }

    }
}
