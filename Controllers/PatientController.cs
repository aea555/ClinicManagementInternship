using ClinicManagementInternship.Dto.Patient;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Patient;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IPatientService service) : GenericController<CreatePatient, UpdatePatient, Models.Patient>(service)
    {
        private readonly IPatientService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,NONE")]
        public override async Task<ActionResult<ServiceResult<Patient>>> CreateNew([FromBody] CreatePatient CreateDto)
        {
            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public override async Task<ActionResult<ServiceResult<Patient>>> Update([FromBody] UpdatePatient UpdateDto)
        {
            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
