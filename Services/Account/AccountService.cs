using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Account
{
    public class AccountService(IGenericRepository<ReturnAccount> repository, DataContext context) : GenericService<CreateAccount, UpdateAccount, ReturnAccount>(repository), IAccountService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<ReturnAccount>> CreateNew(CreateAccount CreateDto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == CreateDto.Email);
                if (existingAccount is not null)
                {
                    return new ServiceResult<ReturnAccount>
                    {
                        Success = false,
                        ErrorMessage = "Email is already used.",
                        StatusCode = 400
                    };
                }
                string HashedPassword = PasswordHash.CreatePasswordHash(CreateDto.PasswordHash);
                CreateDto.PasswordHash = HashedPassword;
                return await base.CreateNew(CreateDto);
            }
            catch (Exception)
            {
                return new ServiceResult<ReturnAccount>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
