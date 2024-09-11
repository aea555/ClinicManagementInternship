using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.AppointmentTestResult
{
    public class CreateAppointmentTestResultAccountId : GenericDTO
    {
        [ValidEntityId<Models.AppointmentTest>("AppointmentTests")]
        public required int AppointmentTestId { get; set; }
        public required decimal Value { get; set; }
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        public required ResultFlag ResultFlag { get; set; }
    }
}
