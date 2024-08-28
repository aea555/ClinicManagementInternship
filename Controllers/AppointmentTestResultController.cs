using ClinicManagementInternship.Dto.AppointmentTestResult;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.AppointmentTestResult;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestResultController(IAppointmentTestResultService service) : GenericController<CreateAppointmentTestResult, UpdateAppointmentTestResult, Models.AppointmentTestResult>(service)
    {
        private readonly IAppointmentTestResultService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,BIOCHEMIST")]
        public override async Task<ActionResult<ServiceResult<AppointmentTestResult>>> CreateNew([FromBody] CreateAppointmentTestResult CreateDto)
        {
            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,BIOCHEMIST")]
        public override async Task<ActionResult<ServiceResult<AppointmentTestResult>>> Update([FromBody] UpdateAppointmentTestResult UpdateDto)
        {
            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
