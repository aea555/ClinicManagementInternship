using ClinicManagementInternship.Dto.Injection;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InjectionController(IGenericService<CreateInjection, UpdateInjection, Injection> service) : GenericController<CreateInjection, UpdateInjection, Models.Injection>(service)
    {
    }
}
