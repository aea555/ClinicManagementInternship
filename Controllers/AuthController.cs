using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Auth;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Utils;
using MailerSend.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(DataContext context, IConfiguration configuration, MailerSendService mailerSend) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly IConfiguration _configuration = configuration;
        private readonly MailerSendService _mailerSend = mailerSend;

        [HttpPost("login")]
        public async Task<ServiceResult<string>> Login([FromBody] LoginRequest model)
        {
            if (string.IsNullOrEmpty(model.Email) || string.IsNullOrEmpty(model.Password))
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Bad request.",
                    StatusCode = 400
                };
            }

            var account = await _context.Accounts.SingleOrDefaultAsync(a => a.Email == model.Email);
            if (account == null)
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Email or password is incorrect.",
                    StatusCode = 401
                };
            }

            if (!PasswordHash.ComparePassword(model.Password, account.PasswordHash))
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Email or password is incorrect.",
                    StatusCode = 401
                };
            }

            var token = JwtManager.GenerateJwt(account, _configuration);

            //var cookieOptions = new CookieOptions
            //{
            //    HttpOnly = true,
            //    Secure = true,
            //    SameSite = SameSiteMode.Strict,
            //    Expires = DateTime.UtcNow.AddDays(7)
            //};

            //Response.Cookies.Append("jwt", token, cookieOptions);

            return new ServiceResult<string>
            {
                Success = true,
                StatusCode = 200,
                Data = token
            };
        }

        [HttpGet("test")]
        [Authorize(Roles = "ADMIN")]
        public ActionResult Test()
        {
            return Ok();
        }

        [HttpPost("send-email")]
        [EnableRateLimiting("emailLimiter")]
        public async Task<ServiceResult<string>> SendEmail([FromBody] EmailVerification dto, CancellationToken ct)
        {
            try
            {
                var random = new Random();
                var confirmationCode = random.Next(100000, 999999).ToString();

                var to = new List<Recipient>()
                {
                    new()
                    {
                        Email = dto.Email,
                        Name = "User",
                        Substitutions = new Dictionary<string, string>()
                        {
                            { "var1", "value1"},
                            { "var2", "value2"}
                        }
                    }
                };

                try
                {
                    var ScEntity = new SignupConfirmation
                    {
                        Email = dto.Email,
                        Code = confirmationCode,
                        ExpiresAt = DateTime.UtcNow.AddMinutes(15)
                    };

                    var tenMinutesAgo = DateTime.UtcNow.AddMinutes(-10);
                    var recentRequest = await _context.SignupConfirmations
                        .AnyAsync(sc => sc.Email == dto.Email && sc.CreatedAt >= tenMinutesAgo, ct);

                    if (recentRequest)
                        return new ServiceResult<string>
                        {
                            Success = false,
                            ErrorMessage = "Çok fazla istek gönderildi, daha sonra tekrar deneyin!",
                            StatusCode = 429
                        };

                    var userAlreadyRegistered = await _context.Accounts.AnyAsync(a => a.Email == dto.Email, cancellationToken: ct);
                    if (userAlreadyRegistered)
                        return new ServiceResult<string>
                        {
                            Success = false,
                            ErrorMessage = "Kullanıcı zaten kaydolmuş",
                            StatusCode = 400
                        };

                    await _mailerSend.SendMailAsync(
                        to, subject: "Doğrulama Kodu", text: "Kayıt için doğrulama kodunuz: " + confirmationCode, cancellationToken: ct);

                    var result = await _context.SignupConfirmations.AddAsync(ScEntity, ct);
                    await _context.SaveChangesAsync(ct);

                    return new ServiceResult<string>
                    {
                        Success = true,
                        StatusCode = 200
                    };

                }
                catch (Exception)
                {
                    return new ServiceResult<string>
                    {
                        Success = false,
                        ErrorMessage = "Unexpected error",
                        StatusCode = 500
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Unexpected error",
                    StatusCode = 500
                };
            }
        }

        [HttpPost("confirm-code")]
        [EnableRateLimiting("emailLimiter")]
        public async Task<ServiceResult<string>> ConfirmCode([FromBody] CodeVerificationDto dto)
        {
            try
            {
                var isValid = await _context.SignupConfirmations.AnyAsync(sc => sc.Email == dto.Email && sc.Code == dto.Code && DateTime.UtcNow < sc.ExpiresAt);
                if (!isValid)
                    return new ServiceResult<string>
                    {
                        Success = false,
                        ErrorMessage = "Code not valid or expired.",
                        StatusCode = 401
                    };

                return new ServiceResult<string>
                {
                    Success = true,
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Unexpected error",
                    StatusCode = 500
                };
            }
        }

        [HttpPost("generateToken/{accountId}")]
        [Authorize(Roles = "NONE,ADMIN")]
        public async Task<ServiceResult<string>> GenerateRoleToken(int accountId, [FromBody] NewTokenReq dto)
        {
            if (!Enum.TryParse(dto.Role, true, out Enums.AccountRole requestedRole) ||
                (requestedRole != Enums.AccountRole.PATIENT &&
                 requestedRole != Enums.AccountRole.DOCTOR &&
                 requestedRole != Enums.AccountRole.BIOCHEMIST))
            {
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "Invalid role requested.",
                    StatusCode = 400
                };
            }

            Console.WriteLine(requestedRole);

            var account = await _context.Accounts.FindAsync(accountId);

            Console.WriteLine(account.Role);


            if (account == null || account.Role != requestedRole)
            {
                Console.WriteLine(account == null || account.Role != requestedRole);
                return new ServiceResult<string>
                {
                    Success = false,
                    ErrorMessage = "No such account or account does not have the requested role.",
                    StatusCode = 401
                };
            }

            var token = JwtManager.GenerateJwt(account, _configuration);

            return new ServiceResult<string>
            {
                Success = true,
                StatusCode = 200,
                Data = token
            };
        }

    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
