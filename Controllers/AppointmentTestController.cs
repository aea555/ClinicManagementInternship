using ClinicManagementInternship.Dto.AppointmentTest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.AppointmentTest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestController(IAppointmentTestService service) : GenericController<CreateAppointmentTest, UpdateAppointmentTest, Models.AppointmentTest>(service)
    {
        private readonly IAppointmentTestService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<AppointmentTest>>> CreateNew([FromBody] CreateAppointmentTest CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<AppointmentTest>>> Update([FromBody] UpdateAppointmentTest UpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }

        [HttpGet("/api/AppointmentTest/GetPending")]
        [Authorize(Roles = "ADMIN,DOCTOR,BIOCHEMIST")]
        public async Task<ActionResult<ServiceResult<List<AppointmentTest>>>> GetPendingTestResults()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetPendingTestResults();
            return HandleResponse(response);
        }

        [HttpGet("/api/AppointmentTest/GetTestResultsOfAppointment/{appointmentId}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<ActionResult<ServiceResult<List<AppointmentTest>>>> GetTestResultsOfAppointment(int appointmentId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetTestResultsOfAppointment(appointmentId);
            return HandleResponse(response);
        }
    }
}