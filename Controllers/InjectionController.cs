using ClinicManagementInternship.Dto.Injection;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Injection;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionController(IInjectionService service) : GenericController<CreateInjection, UpdateInjection, Models.Injection>(service)
    {
        private readonly IInjectionService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<Injection>>> CreateNew([FromBody] CreateInjection CreateDto)
        {
            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<Injection>>> Update([FromBody] UpdateInjection UpdateDto)
        {
            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
