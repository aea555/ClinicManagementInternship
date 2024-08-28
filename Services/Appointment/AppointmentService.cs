using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Appointment
{
    public class AppointmentService(IGenericRepository<Models.Appointment> repository) : GenericService<CreateAppointment, UpdateAppointment, Models.Appointment>(repository), IAppointmentService
    {
    }
}
