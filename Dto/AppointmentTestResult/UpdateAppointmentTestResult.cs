using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.AppointmentTestResult
{
    public class UpdateAppointmentTestResult : GenericUpdateDTO
    {
        public required int AppointmentTestId { get; set; }
        public DateTime? ResultDate { get; set; }
        public decimal? Value { get; set; }
        public required int BiochemistId { get; set; }
        public ResultFlag? ResultFlag { get; set; }
    }
}
