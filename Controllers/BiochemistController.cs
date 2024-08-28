using ClinicManagementInternship.Dto.Biochemist;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiochemistController(IGenericService<CreateBiochemist, UpdateBiochemist, Biochemist> service) : GenericController<CreateBiochemist, UpdateBiochemist, Models.Biochemist>(service)
    {
    }
}
