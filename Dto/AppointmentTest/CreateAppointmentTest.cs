using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.AppointmentTest
{
    public class CreateAppointmentTest : GenericDTO
    {
        public required int AppointmentId { get; set; }
        public required int TestId { get; set; }
    }
}
