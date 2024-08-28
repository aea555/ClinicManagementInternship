using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Appointment
{
    public class AppointmentService(IGenericRepository<Models.Appointment> repository, DataContext context) : GenericService<CreateAppointment, UpdateAppointment, Models.Appointment>(repository), IAppointmentService
    {
        private readonly DataContext _context = context;

        public async Task<ServiceResult<Models.Appointment>> CancelAppointment(int id)
        {
            try
            {
                var existingAppointment = await _context.Appointments.FindAsync(id);
                if (existingAppointment is not null)
                {
                    existingAppointment.AppointmentStatus = Enums.AppointmentStatus.CANCELLED;
                    await _context.SaveChangesAsync();
                    return new ServiceResult<Models.Appointment>
                    {
                        Success = true,
                        StatusCode = 200,
                        Message = "Appointment cancelled."
                    };
                }
                else
                {
                    return new ServiceResult<Models.Appointment>
                    {
                        Success = false,
                        ErrorMessage = "Appointment doesn't exist.",
                        StatusCode = 400
                    };
                }

            }
            catch (Exception)
            {
                return new ServiceResult<Models.Appointment>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
