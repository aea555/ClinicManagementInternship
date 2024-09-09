using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Appointment;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IAppointmentService service) : GenericController<CreateAppointment, UpdateAppointment, Models.Appointment>(service)
    {
        private readonly IAppointmentService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public override async Task<ActionResult<ServiceResult<Models.Appointment>>> CreateNew([FromBody] CreateAppointment CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPost("/api/Appointment/CreateWithAccountId")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<Models.Appointment>>> CreateWithAccountId([FromBody] CreateAppointmentAccountId CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateWithAccountId(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut("/api/Appointment/Cancel/{id}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<Models.Appointment>>> Cancel(int id)
        {
            var response = await _service.CancelAppointment(id);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<Models.Appointment>>> Update([FromBody] UpdateAppointment UpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }

        [HttpGet("/api/Appointment/GetPossibleAppointments/{clinicId}")]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public async Task<ActionResult<ServiceResult<List<PossibleAppointments>>>> GetPossibleAppointments(int clinicId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.GetFreeAppointmentsOfToday(clinicId);
            return HandleResponse(response);
        }
    }
}
