using ClinicManagementInternship.Enums;

namespace ClinicManagementInternship.Models
{
    public class AppointmentTestResult : ModelBase
    {
        public required int AppointmentTestId { get; set; }
        public AppointmentTest? AppointmentTest { get; set; }
        public required DateTime ResultDate { get; set; } = DateTime.UtcNow;
        public required decimal Value { get; set; }
        public required int BiochemistId { get; set; }
        public Biochemist? Biochemist { get; set; }
        public required ResultFlag ResultFlag { get; set; }
    }
}
