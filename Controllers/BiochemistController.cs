using ClinicManagementInternship.Dto.Biochemist;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Biochemist;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiochemistController(IBiochemistService service) : GenericController<CreateBiochemist, UpdateBiochemist, Models.Biochemist>(service)
    {
        private readonly IBiochemistService _service = service;

        [HttpPut]
        [Authorize(Roles = "ADMIN,BIOCHEMIST")]
        public override async Task<ActionResult<ServiceResult<Biochemist>>> Update([FromBody] UpdateBiochemist UpdateDto)
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
