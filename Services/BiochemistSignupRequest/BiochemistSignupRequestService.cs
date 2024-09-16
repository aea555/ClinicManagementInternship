using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.BiochemistSignupRequest;
using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using MailerSend.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.BiochemistSignupRequest
{
    public class BiochemistSignupRequestService(IGenericRepository<Models.BiochemistSignupRequest> repository, DataContext context, MailerSendService mailerSend) : GenericService<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, Models.BiochemistSignupRequest>(repository), IBiochemistSignupRequestService
    {
        private readonly DataContext _context = context;
        private readonly MailerSendService _mailerSend = mailerSend;

        public override async Task<ServiceResult<Models.BiochemistSignupRequest>> CreateNew(CreateBiochemistSignupRequest CreateDto)
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
                        return new ServiceResult<Models.BiochemistSignupRequest>
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
                        return new ServiceResult<Models.BiochemistSignupRequest>
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
                        return new ServiceResult<Models.BiochemistSignupRequest>
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
                    return new ServiceResult<Models.BiochemistSignupRequest>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResult<Models.BiochemistSignupRequest>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public override async Task<ServiceResult<Models.BiochemistSignupRequest>> Update(UpdateBiochemistSignupRequest UpdateDto)
        {
            try
            {
                var request = await _context.BiochemistSignupRequests.Include(bsr => bsr.Account).FirstOrDefaultAsync(bsr => bsr.Id == UpdateDto.Id);
                var to = new List<Recipient>()
                {
                    new()
                    {
                        Email = request.Account.Email,
                        Name = "User",
                        Substitutions = new Dictionary<string, string>()
                        {
                            { "var1", "value1"},
                            { "var2", "value2"}
                        }
                    }
                };

                if (TryGetEmailBody(UpdateDto.SignUpRequest, out string emailBody))
                {
                    await _mailerSend.SendMailAsync(
                        to,
                        subject: "Başvurunuzun Durumu",
                        text: null,
                        html: emailBody
                    );
                }

                return await base.Update(UpdateDto);
            }
            catch (Exception)
            {
                return new ServiceResult<Models.BiochemistSignupRequest>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        private static bool TryGetEmailBody(SignUpRequestStatus status, out string emailBody)
        {
            emailBody = null;

            switch (status)
            {
                case SignUpRequestStatus.ACCEPTED:
                    emailBody = @"
                <p>Biyokimyager kaydı için oluşturduğunuz başvurunuz onaylandı. Yeni rolünüzle uygulamayı kullanabilmek için sisteme yeniden giriş yapın.
                Uygulamaya gitmek için <a href='https://client-clinicapp.vercel.app/dashboard'>buraya tıklayın.</a></p>";
                    return true;

                case SignUpRequestStatus.DENIED:
                    emailBody = @"
                <p>Biyokimyager kaydı için oluşturduğunuz başvurunuz reddedildi. Bilgilerinizi gözden geçirip tekrar başvurmayı deneyin.
                Uygulamaya gitmek için <a href='https://client-clinicapp.vercel.app/dashboard'>buraya tıklayın.</a></p>";
                    return true;

                case SignUpRequestStatus.PENDING:
                default:
                    return false;
            }
        }
    }
}
