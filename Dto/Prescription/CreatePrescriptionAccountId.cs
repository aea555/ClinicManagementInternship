using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Prescription
{
    public class CreatePrescriptionAccountId : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        [ValidEntityId<Models.Patient>("Patients")]
        public required int PatientId { get; set; }
        [ValidEntityId<Models.Appointment>("Appointments")]
        public required int AppointmentId { get; set; }
        public required int DurationDays { get; set; }
        public string? Notes { get; set; }
    }
}
