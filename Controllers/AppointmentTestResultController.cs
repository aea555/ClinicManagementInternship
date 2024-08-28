using ClinicManagementInternship.Dto.AppointmentTestResult;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestResultController(IGenericService<CreateAppointmentTestResult, UpdateAppointmentTestResult, AppointmentTestResult> service) : GenericController<CreateAppointmentTestResult, UpdateAppointmentTestResult, Models.AppointmentTestResult>(service)
    {
    }
}
