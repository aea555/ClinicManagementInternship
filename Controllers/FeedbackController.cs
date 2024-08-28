using ClinicManagementInternship.Dto.Feedback;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Feedback;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController(IFeedbackService service) : GenericController<CreateFeedback, UpdateFeedback, Models.Feedback>(service)
    {
        private readonly IFeedbackService _service = service;

        [HttpPost]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public override async Task<ActionResult<ServiceResult<Feedback>>> CreateNew([FromBody] CreateFeedback CreateDto)
        {
            var response = await _service.CreateNew(CreateDto);
            return HandleResponse(response);
        }

        [HttpPut]
        [Authorize(Roles = "ADMIN,PATIENT")]
        public override async Task<ActionResult<ServiceResult<Feedback>>> Update([FromBody] UpdateFeedback UpdateDto)
        {
            var response = await _service.Update(UpdateDto);
            return HandleResponse(response);
        }
    }
}
