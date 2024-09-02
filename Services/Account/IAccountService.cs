using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Account
{
    public interface IAccountService : IGenericService<CreateAccount, UpdateAccount, Models.Account>
    {
        Task<ServiceResult<SignupRequestsResult>> GetRequestsOfAccount(GetRequestAccountId dto);
    }
}
