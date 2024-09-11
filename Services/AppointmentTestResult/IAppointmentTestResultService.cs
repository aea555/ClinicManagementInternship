using ClinicManagementInternship.Dto.AppointmentTestResult;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.AppointmentTestResult
{
    public interface IAppointmentTestResultService : IGenericService<CreateAppointmentTestResult, UpdateAppointmentTestResult, Models.AppointmentTestResult>
    {
        Task<ServiceResult<Models.AppointmentTestResult>> CreateWithAccountId(CreateAppointmentTestResultAccountId CreateDto);
    }
}
