using ClinicManagementInternship.Dto.DoctorSignupRequest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorSignupRequestController(IGenericService<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, DoctorSignupRequest> service) : GenericController<CreateDoctorSignupRequest, UpdateDoctorSignupRequest, Models.DoctorSignupRequest>(service)
    {
    }
}
