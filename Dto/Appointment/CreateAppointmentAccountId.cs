using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Appointment
{
    public class CreateAppointmentAccountId : GenericDTO
    {
        [ValidEntityId<Models.Clinic>("Clinics")]
        public required int ClinicId { get; set; }
        [ValidEntityId<Models.Doctor>("Doctors")]
        public required int DoctorId { get; set; }
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        public required DateTime StartTime { get; set; }
    }
}
