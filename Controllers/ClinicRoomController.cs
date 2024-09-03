using ClinicManagementInternship.Dto.ClinicRoom;
using ClinicManagementInternship.Services.ClinicRoom;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicRoomController(IClinicRoomService service) : GenericController<CreateClinicRoom, UpdateClinicRoom, Models.ClinicRoom>(service)
    {
        private readonly IClinicRoomService _service = service;
        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.ClinicRoom>>> CreateNew([FromBody] CreateClinicRoom createDto)
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
        public override async Task<ActionResult<ServiceResult<Models.ClinicRoom>>> Update([FromBody] UpdateClinicRoom updateDto)
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
