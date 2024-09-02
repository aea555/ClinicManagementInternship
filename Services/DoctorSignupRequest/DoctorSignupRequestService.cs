using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Dto.DoctorSignupRequest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.DoctorSignupRequest
{
    public class DoctorSignupRequestService(IGenericRepository<Models.DoctorSignupRequest> repository, DataContext context) : GenericService<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, Models.DoctorSignupRequest>(repository), IDoctorSignupRequestService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.DoctorSignupRequest>> CreateNew(CreateDoctorSignupRequest CreateDto)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(CreateDto.AccountId);
                if (account is not null)
                {
                    bool isPatient = await _context.Patients.AnyAsync(p => p.AccountId == CreateDto.AccountId);
                    bool isDoctor = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);
                    bool isBiochemist = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);

                    if (isPatient || isDoctor || isBiochemist)
                    {
                        return new ServiceResult<Models.DoctorSignupRequest>
                        {
                            Success = false,
                            ErrorMessage = "User is already registered as a patient, doctor or biochemist!",
                            StatusCode = 400
                        };
                    }

                    var doctorRequests = await _context.DoctorSignupRequests
                        .Where(dsr => dsr.AccountId == CreateDto.AccountId)
                        .ToListAsync();

                    if (doctorRequests.Any(dsr => dsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED ||
                                                  dsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING))
                    {
                        return new ServiceResult<Models.DoctorSignupRequest>
                        {
                            Success = false,
                            ErrorMessage = "User already has a request for signing up as a Doctor!",
                            StatusCode = 400
                        };
                    }

                    var biochemistRequests = await _context.BiochemistSignupRequests
                        .Where(bsr => bsr.AccountId == CreateDto.AccountId)
                        .ToListAsync();

                    if (biochemistRequests.Any(bsr => bsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED ||
                                                      bsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING))
                    {
                        return new ServiceResult<Models.DoctorSignupRequest>
                        {
                            Success = false,
                            ErrorMessage = "User already has a request for signing up as a Biochemist!",
                            StatusCode = 400
                        };
                    }

                    return await base.CreateNew(CreateDto);
                }
                else
                {
                    return new ServiceResult<Models.DoctorSignupRequest>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResult<Models.DoctorSignupRequest>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<Models.DoctorSignupRequest>> GetRequestsOfAccount(GetRequestAccountId dto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FindAsync(dto.AccountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<Models.DoctorSignupRequest>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }

                var requests = await _context.DoctorSignupRequests.FirstOrDefaultAsync(dsr => dsr.AccountId == dto.AccountId &&
                (dsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING || dsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED));

                return new ServiceResult<Models.DoctorSignupRequest>
                {
                    Success = true,
                    Message = "Records found",
                    Data = requests,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<Models.DoctorSignupRequest>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
