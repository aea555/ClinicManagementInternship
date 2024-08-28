using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Account
{
    public class AccountService(IGenericRepository<Models.Account> repository, DataContext context) : GenericService<CreateAccount, UpdateAccount, Models.Account>(repository), IAccountService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Account>> CreateNew(CreateAccount CreateDto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == CreateDto.Email);
                if (existingAccount is not null)
                {
                    return new ServiceResult<Models.Account>
                    {
                        Success = false,
                        ErrorMessage = "Email is already used.",
                        StatusCode = 400
                    };
                }
                string HashedPassword = PasswordHash.CreatePasswordHash(CreateDto.PasswordHash);
                CreateDto.PasswordHash = HashedPassword;
                var account = await base.CreateNew(CreateDto);

                var returnObj = account.Data;
                returnObj.PasswordHash = "";

                return new ServiceResult<Models.Account>
                {
                    Success = true,
                    Data = returnObj,
                    StatusCode = 201
                };
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Account>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
