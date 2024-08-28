using ClinicManagementInternship.Dto.Feedback;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController(IGenericService<CreateFeedback, UpdateFeedback, Feedback> service) : GenericController<CreateFeedback, UpdateFeedback, Models.Feedback>(service)
    {
    }
}
