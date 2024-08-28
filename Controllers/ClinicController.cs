using ClinicManagementInternship.Dto.Clinic;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClinicController(IGenericService<CreateClinic, UpdateClinic, Clinic> service) : GenericController<CreateClinic, UpdateClinic, Models.Clinic>(service)
    {
    }
}
