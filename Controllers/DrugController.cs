using ClinicManagementInternship.Dto.Drug;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController(IGenericService<CreateDrug, UpdateDrug, Drug> service) : GenericController<CreateDrug, UpdateDrug, Drug>(service)
    {
    }
}
