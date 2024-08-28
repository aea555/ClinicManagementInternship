using ClinicManagementInternship.Dto.AppointmentTest;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentTestController(IGenericService<CreateAppointmentTest, UpdateAppointmentTest, AppointmentTest> service) : GenericController<CreateAppointmentTest, UpdateAppointmentTest, Models.AppointmentTest>(service)
    {
    }
}
