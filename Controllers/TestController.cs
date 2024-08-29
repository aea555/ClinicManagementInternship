using ClinicManagementInternship.Dto.Test;
using ClinicManagementInternship.Services.Test;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(ITestService service) : GenericController<CreateTest, UpdateTest, Models.Test>(service)
    {
    }
}
