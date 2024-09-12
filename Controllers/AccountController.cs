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

        [HttpPut]
        [Authorize(Roles = "ADMIN,PATIENT,DOCTOR,BIOCHEMIST")]
        public override async Task<ActionResult<ServiceResult<Models.Account>>> Update([FromBody] UpdateAccount updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(updateDto);
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

        [HttpGet("/api/GetAppointmentsOfAccount/{accountId}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<List<Models.Appointment>>>> GetAppointmentsOfAccount(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetAppointmentsOfAccount(accountId);
            return HandleResponse(response);
        }

        [HttpGet("/api/GetPrescriptionsOfAccount/{accountId}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<List<Models.Prescription>>>> GetPrescriptionsOfAccount(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetPrescriptionsOfAccount(accountId);
            return HandleResponse(response);
        }

        [HttpGet("/api/GetTestResultsOfAccount/{accountId}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<List<Models.AppointmentTestResult>>>> GetTestResultsOfAccount(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetTestResultsOfAccount(accountId);
            return HandleResponse(response);
        }

        [HttpGet("/api/GetInjectionsOfAccount/{accountId}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<List<Models.Injection>>>> GetInjectionsOfAccount(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetInjectionsOfAccount(accountId);
            return HandleResponse(response);
        }

        [HttpGet("/api/GetUpcomingAppointments/{accountId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<ActionResult<ServiceResult<List<Models.Appointment>>>> GetUpcomingAppointments(int accountId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetUpcomingAppointments(accountId);
            return HandleResponse(response);
        }

        [HttpPost("/api/Account/ConfirmEmail")]
        [Authorize(Roles = "ADMIN,DOCTOR,PATIENT,BIOCHEMIST,NONE")]
        public async Task<ActionResult<ServiceResult<Models.Account>>> ConfirmEmail([FromBody] ConfirmEmail CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.ConfirmEmail(CreateDto.AccountId, CreateDto.Email);
            return HandleResponse(response);
        }

        [HttpPost("/api/Account/ConfirmPassword")]
        [Authorize(Roles = "ADMIN,DOCTOR,PATIENT,BIOCHEMIST,NONE")]
        public async Task<ActionResult<ServiceResult<Models.Account>>> ConfirmPassword([FromBody] ConfirmPassword CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.ConfirmPassword(CreateDto.AccountId, CreateDto.Password);
            return HandleResponse(response);
        }
    }
}
