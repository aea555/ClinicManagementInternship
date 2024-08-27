using ClinicManagementInternship.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class AppointmentTestResult
    {
        [Key]
        public int Id { get; set; }
        public required int AppointmentTestId { get; set; }
        public AppointmentTest? AppointmentTest { get; set; }
        public required DateTime ResultDate { get; set; }
        public required decimal Value { get; set; }
        public required int BiochemistId { get; set; }
        public Biochemist? Biochemist { get; set; }
        public ResultFlag ResultFlag { get; set; }
    }
}
