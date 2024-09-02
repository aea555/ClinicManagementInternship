using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Doctor;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IDoctorService service) : GenericController<CreateDoctor, UpdateDoctor, Models.Doctor>(service)
    {
        private readonly IDoctorService _service = service;

        [HttpPut("{id}")]
        [Authorize(Roles = "ADMIN,DOCTOR")]
        public async Task<ActionResult<ServiceResult<Doctor>>> UpdateDoctorName(int id, string FirstName, string LastName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var response = await _service.UpdateDoctorName(id, FirstName, LastName);
            return HandleResponse(response);
        }
    }
}
