using ClinicManagementInternship.Dto.Clinic;
using ClinicManagementInternship.Services.Clinic;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(IClinicService service) : GenericController<CreateClinic, UpdateClinic, Models.Clinic>(service)
    {
    }
}
