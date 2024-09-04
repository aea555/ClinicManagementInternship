namespace ClinicManagementInternship.Models
{
    public class AppointmentTest : ModelBase
    {
        public required int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public required int TestId { get; set; }
        public Test? Test { get; set; }
    }
}
