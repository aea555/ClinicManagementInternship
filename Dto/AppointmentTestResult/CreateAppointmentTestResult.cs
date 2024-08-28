using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.AppointmentTestResult
{
    public class CreateAppointmentTestResult : GenericDTO
    {
        public required int AppointmentTestId { get; set; }
        public required DateTime ResultDate { get; set; }
        public required decimal Value { get; set; }
        public required int BiochemistId { get; set; }
        public required ResultFlag ResultFlag { get; set; }
    }
}
