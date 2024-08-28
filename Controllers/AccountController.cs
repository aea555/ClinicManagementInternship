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
            var response = await _service.CreateNew(createDto);
            return HandleResponse(response);
        }
    }
}
