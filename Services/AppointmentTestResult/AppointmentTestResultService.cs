using ClinicManagementInternship.Dto.AppointmentTestResult;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.AppointmentTestResult
{
    public class AppointmentTestResultService(IGenericRepository<Models.AppointmentTestResult> repository) : GenericService<CreateAppointmentTestResult, UpdateAppointmentTestResult, Models.AppointmentTestResult>(repository), IAppointmentTestResultService
    {
    }
}
