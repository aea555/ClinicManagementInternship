using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Feedback
{
    public class CreateFeedback : GenericDTO
    {
        public required int PatientId { get; set; }
        public required int DoctorId { get; set; }
        public required int AppointmentId { get; set; }
        public required int Rating { get; set; }
        public string? Comment { get; set; }
    }
}
