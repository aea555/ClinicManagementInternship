using ClinicManagementInternship.Dto.BiochemistSignupRequest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BiochemistSignupRequestController(IGenericService<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, BiochemistSignupRequest> service) : GenericController<CreateBiochemistSignupRequest, UpdateBiochemistSignupRequest, Models.BiochemistSignupRequest>(service)
    {
    }
}
