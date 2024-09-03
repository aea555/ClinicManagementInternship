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

        //[HttpDelete("{id}")]
        //[Authorize(Roles = "ADMIN,DOCTOR")]
        //public override async Task<ActionResult<ServiceResult<string>>> DeleteById(int id)
        //{
        //    var response = await _service.DeleteById(id);
        //    return HandleResponse(response);
        //}
    }
}
