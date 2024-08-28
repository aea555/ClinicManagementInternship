using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.AppointmentTest
{
    public class UpdateAppointmentTest : GenericUpdateDTO
    {
        public int? AppointmentId { get; set; }
        public int? TestId { get; set; }
    }
}
