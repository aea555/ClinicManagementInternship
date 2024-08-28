using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTest
{
    public class UpdateAppointmentTest : GenericUpdateDTO
    {
        [ValidEntityId<Models.Appointment>("Appointments")]
        public int? AppointmentId { get; set; }
        [ValidEntityId<Models.Test>("Tests")]
        public int? TestId { get; set; }
    }
}
