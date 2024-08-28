using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Prescription
{
    public class CreatePrescription : GenericDTO
    {
        public required int DoctorId { get; set; }
        public required int PatientId { get; set; }
        public required int AppointmentId { get; set; }
        public required DateTime Date { get; set; }
        public required int DurationDays { get; set; }
        public string? Notes { get; set; }
    }
}
