using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController(IGenericService<CreateDoctor, UpdateDoctor, Doctor> service) : GenericController<CreateDoctor, UpdateDoctor, Models.Doctor>(service)
    {
    }
}
