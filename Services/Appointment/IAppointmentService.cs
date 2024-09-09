using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Appointment
{
    public interface IAppointmentService : IGenericService<CreateAppointment, UpdateAppointment, Models.Appointment>
    {
        Task<ServiceResult<Models.Appointment>> CancelAppointment(int id);
        Task<ServiceResult<List<Models.PossibleAppointments>>> GetFreeAppointmentsOfToday(int clinicId);
        Task<ServiceResult<Models.Appointment>> CreateWithAccountId(CreateAppointmentAccountId CreateDto);
    }
}
