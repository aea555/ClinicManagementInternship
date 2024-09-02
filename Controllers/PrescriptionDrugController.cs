using ClinicManagementInternship.Dto.PrescriptionDrug;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.PrescriptionDrug;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionDrugController(IPrescriptionDrugService service) : GenericController<CreatePrescriptionDrug, UpdatePrescriptionDrug, Models.PrescriptionDrug>(service)
    {
        private readonly IPrescriptionDrugService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<PrescriptionDrug>>> CreateNew([FromBody] CreatePrescriptionDrug CreateDto)
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
        public override async Task<ActionResult<ServiceResult<PrescriptionDrug>>> Update([FromBody] UpdatePrescriptionDrug UpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
