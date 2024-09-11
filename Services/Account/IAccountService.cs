using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Account
{
    public interface IAccountService : IGenericService<CreateAccount, UpdateAccount, Models.Account>
    {
        Task<ServiceResult<SignupRequestsResult>> GetRequestsOfAccount(GetRequestAccountId dto);
        Task<ServiceResult<List<Models.Appointment>>> GetAppointmentsOfAccount(int accountId);
        Task<ServiceResult<List<Models.Prescription>>> GetPrescriptionsOfAccount(int accountId);
        Task<ServiceResult<List<Models.AppointmentTestResult>>> GetTestResultsOfAccount(int accountId);
        Task<ServiceResult<List<Models.Appointment>>> GetUpcomingAppointments(int accountId);
        Task<ServiceResult<List<Models.Injection>>> GetInjectionsOfAccount(int accountId);
    }
}
