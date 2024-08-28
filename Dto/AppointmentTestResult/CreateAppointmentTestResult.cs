using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTestResult
{
    public class CreateAppointmentTestResult : GenericDTO
    {
        [ValidEntityId<Models.AppointmentTest>("AppointmentTests")]
        public required int AppointmentTestId { get; set; }
        public required DateTime ResultDate { get; set; }
        public required decimal Value { get; set; }
        [ValidEntityId<Models.Biochemist>("Biochemists")]
        public required int BiochemistId { get; set; }
        public required ResultFlag ResultFlag { get; set; }
    }
}
