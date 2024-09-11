using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.AppointmentTest;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.AppointmentTest
{
    public class AppointmentTestService(IGenericRepository<Models.AppointmentTest> repository, DataContext context) : GenericService<CreateAppointmentTest, UpdateAppointmentTest, Models.AppointmentTest>(repository), IAppointmentTestService
    {
        private readonly DataContext _context = context;

        public async Task<ServiceResult<List<Models.AppointmentTest>>> GetPendingTestResults()
        {
            try
            {
                var tests = await _context.AppointmentTests
                .Include(at => at.Test)
                .Where(at => !_context.AppointmentTestResults
                .Any(atr => atr.AppointmentTestId == at.Id))
                .ToListAsync();

                return new ServiceResult<List<Models.AppointmentTest>>
                {
                    Success = true,
                    Message = "Tests without results found",
                    Data = tests,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.AppointmentTest>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }


        }

        public async Task<ServiceResult<List<Models.AppointmentTest>>> GetTestResultsOfAppointment(int appointmentId)
        {
            try
            {
                var appointment = await _context.Appointments.FindAsync(appointmentId);
                if (appointment is null)
                {
                    return new ServiceResult<List<Models.AppointmentTest>>
                    {
                        Success = false,
                        StatusCode = 404,
                        ErrorMessage = "Invalid Appointment Id.",
                    };
                }

                var results = await _context.AppointmentTests
                    .Include(at => at.Test)
                    .Include(at => at.Appointment)
                    .Where(at => at.AppointmentId == appointmentId)
                    .Select(at => new
                    {
                        at.Id,
                        TestName = at.Test.Name,
                        at.Test.UnitType,
                        at.Appointment.PatientId,
                        AppointmentTestResults = _context.AppointmentTestResults
                            .Where(atr => atr.AppointmentTestId == at.Id)
                            .Select
                            (
                                atr => new
                                {
                                    atr.Id,
                                    atr.Value,
                                    atr.ResultDate,
                                    atr.ResultFlag
                                }
                            )
                            .ToList()
                    })
                    .ToListAsync();

                return new ServiceResult<List<Models.AppointmentTest>>
                {
                    StatusCode = 200,
                    Success = true,
                    ExtraData = results
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.AppointmentTest>>
                {
                    Success = false,
                    StatusCode = 500,
                    ErrorMessage = "Unexpected error.",
                };
            }

        }
    }
}
