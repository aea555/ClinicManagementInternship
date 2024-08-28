using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using Microsoft.AspNetCore.Mvc;

namespace ClinicManagementInternship.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentController(IGenericService<CreateAppointment, UpdateAppointment, Appointment> service) : GenericController<CreateAppointment, UpdateAppointment, Models.Appointment>(service)
    {
    }
}
