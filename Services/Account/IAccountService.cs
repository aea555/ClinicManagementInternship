using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Account
{
    public interface IAccountService : IGenericService<CreateAccount, UpdateAccount, Models.Account>
    {
    }
}
