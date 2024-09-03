using ClinicManagementInternship.Dto.Drug;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Drug;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController(IDrugService service) : GenericController<CreateDrug, UpdateDrug, Drug>(service)
    {
        private readonly IDrugService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN")]
        public override async Task<ActionResult<ServiceResult<Models.Drug>>> CreateNew([FromBody] CreateDrug createDto)
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
        public override async Task<ActionResult<ServiceResult<Models.Drug>>> Update([FromBody] UpdateDrug updateDto)
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
