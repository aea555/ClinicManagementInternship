using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTestResult
{
    public class UpdateAppointmentTestResult : GenericUpdateDTO
    {
        [ValidEntityId<Models.AppointmentTest>("AppointmentTests")]
        public required int AppointmentTestId { get; set; }
        public DateTime? ResultDate { get; set; }
        public decimal? Value { get; set; }
        [ValidEntityId<Models.Biochemist>("Biochemists")]
        public required int BiochemistId { get; set; }
        public ResultFlag? ResultFlag { get; set; }
    }
}
