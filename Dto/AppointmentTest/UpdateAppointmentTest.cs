using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTest
{
    public class UpdateAppointmentTest : GenericUpdateDTO
    {
        [ValidEntityId<Models.Appointment>("Appointments", isRequired: false)]
        public int? AppointmentId { get; set; }
        [ValidEntityId<Models.Test>("Tests", isRequired: false)]
        public int? TestId { get; set; }
    }
}
