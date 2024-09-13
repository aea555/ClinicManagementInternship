using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Auth;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Utils;
using MailerSend.AspNetCore;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult Test()
        {
            return Ok();
        }

        [HttpPost("send-email")]
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
                        Code = confirmationCode
                    };

                    var result = await _context.SignupConfirmations.AddAsync(ScEntity, ct);
                    await _context.SaveChangesAsync(ct);

                    await _mailerSend.SendMailAsync(
                        to, subject: "Doğrulama Kodu", text: "Kayıt için doğrulama kodunuz: " + confirmationCode, cancellationToken: ct);

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
        public async Task<ServiceResult<string>> ConfirmCode([FromBody] CodeVerificationDto dto)
        {
            try
            {
                var isValid = await _context.SignupConfirmations.AnyAsync(sc => sc.Email == dto.Email && sc.Code == dto.Code);
                if (!isValid)
                    return new ServiceResult<string>
                    {
                        Success = false,
                        ErrorMessage = "Code not valid",
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
    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
