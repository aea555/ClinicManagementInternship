using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Admin;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController(IAdminService service) : GenericController<CreateAdmin, UpdateAdmin, Admin>(service)
    {
        private readonly IAdminService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.Admin>>> CreateNew([FromBody] CreateAdmin createDto)
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
        public override async Task<ActionResult<ServiceResult<Models.Admin>>> Update([FromBody] UpdateAdmin updateDto)
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
