using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Services.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController(IAccountService service) : GenericController<CreateAccount, UpdateAccount, Models.Account>(service)
    {
        private readonly IAccountService _service = service;

        [HttpPost]
        [AllowAnonymous]
        public override async Task<ActionResult<ServiceResult<Models.Account>>> CreateNew([FromBody] CreateAccount createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(createDto);
            return HandleResponse(response);
        }

        [HttpGet("/api/GetRequestsOfAccount/{accountId}")]
        [Authorize(Roles = "ADMIN,NONE")]
        public async Task<ActionResult<ServiceResult<SignupRequestsResult>>> GetRequestsOfAccount(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dto = new GetRequestAccountId { AccountId = accountId };

            var response = await _service.GetRequestsOfAccount(dto);
            return HandleResponse(response);
        }
    }
}
