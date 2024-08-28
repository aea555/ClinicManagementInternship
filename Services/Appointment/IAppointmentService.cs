using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Appointment
{
    public interface IAppointmentService : IGenericService<CreateAppointment, UpdateAppointment, Models.Appointment>
    {
    }
}
