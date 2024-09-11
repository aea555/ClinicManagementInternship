using ClinicManagementInternship.Dto.AppointmentTest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.AppointmentTest
{
    public interface IAppointmentTestService : IGenericService<CreateAppointmentTest, UpdateAppointmentTest, Models.AppointmentTest>
    {
        Task<ServiceResult<List<Models.AppointmentTest>>> GetPendingTestResults();
        Task<ServiceResult<List<Models.AppointmentTest>>> GetTestResultsOfAppointment(int appointmentId);
    }
}
