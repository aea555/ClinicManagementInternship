using ClinicManagementInternship.Data;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(DataContext context, IConfiguration configuration) : ControllerBase
    {
        private readonly DataContext _context = context;
        private readonly IConfiguration _configuration = configuration;

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

    }

    public class LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
