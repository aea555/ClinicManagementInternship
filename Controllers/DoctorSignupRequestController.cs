using ClinicManagementInternship.Dto.DoctorSignupRequest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.DoctorSignupRequest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSignupRequestController(IDoctorSignupRequestService service) : GenericController<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, Models.DoctorSignupRequest>(service)
    {
        private readonly IDoctorSignupRequestService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,NONE")]
        public override async Task<ActionResult<ServiceResult<DoctorSignupRequest>>> CreateNew([FromBody] CreateDoctorSignupRequest CreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.DoctorSignupRequest>>> Update([FromBody] UpdateDoctorSignupRequest updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(updateDto);
            return HandleResponse(response);
        }
    }
}
