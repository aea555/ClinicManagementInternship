using ClinicManagementInternship.Dto.Clinic;
using ClinicManagementInternship.Services.Clinic;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(IClinicService service) : GenericController<CreateClinic, UpdateClinic, Models.Clinic>(service)
    {
        private readonly IClinicService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.Clinic>>> CreateNew([FromBody] CreateClinic createDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.CreateNew(createDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.Clinic>>> Update([FromBody] UpdateClinic updateDto)
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
