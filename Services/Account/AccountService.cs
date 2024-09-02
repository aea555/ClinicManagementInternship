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

        public async Task<ServiceResult<SignupRequestsResult>> GetRequestsOfAccount(GetRequestAccountId dto)
        {
            try
            {
                var requestsDoctor = await _context.DoctorSignupRequests.FirstOrDefaultAsync(dsr => dsr.AccountId == dto.AccountId &&
                (dsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING || dsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED));

                var requestsBiochemist = await _context.BiochemistSignupRequests.FirstOrDefaultAsync(bsr => bsr.AccountId == dto.AccountId &&
                (bsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING || bsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED));

                var returnObj = new SignupRequestsResult
                {
                    DoctorSignupRequest = requestsDoctor,
                    BiochemistSignupRequest = requestsBiochemist
                };

                return new ServiceResult<SignupRequestsResult>
                {
                    Success = true,
                    Message = "Records found",
                    Data = returnObj,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<SignupRequestsResult>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
