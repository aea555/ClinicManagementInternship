using ClinicManagementInternship.Dto.Drug;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Services.Drug;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController(IDrugService service) : GenericController<CreateDrug, UpdateDrug, Drug>(service)
    {
    }
}
