using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTest
{
    public class CreateAppointmentTest : GenericDTO
    {
        [ValidEntityId<Models.Appointment>("Appointments")]
        public required int AppointmentId { get; set; }
        [ValidEntityId<Models.Test>("Tests")]
        public required int TestId { get; set; }
    }
}
