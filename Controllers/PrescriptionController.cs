using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Prescription;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionController(IPrescriptionService service) : GenericController<CreatePrescription, UpdatePrescription, Models.Prescription>(service)
    {
        private readonly IPrescriptionService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<Prescription>>> CreateNew([FromBody] CreatePrescription CreateDto)
        {
            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public override async Task<ActionResult<ServiceResult<Prescription>>> Update([FromBody] UpdatePrescription UpdateDto)
        {
            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
