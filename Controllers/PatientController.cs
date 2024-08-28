using ClinicManagementInternship.Dto.Patient;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController(IGenericService<CreatePatient, UpdatePatient, Patient> service) : GenericController<CreatePatient, UpdatePatient, Models.Patient>(service)
    {
    }
}
