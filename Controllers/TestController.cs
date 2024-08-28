using ClinicManagementInternship.Dto.Test;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController(IGenericService<CreateTest, UpdateTest, Test> service) : GenericController<CreateTest, UpdateTest, Models.Test>(service)
    {
    }
}
