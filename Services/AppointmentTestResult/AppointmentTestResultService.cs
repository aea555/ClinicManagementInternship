using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.AppointmentTestResult;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.AppointmentTestResult
{
    public class AppointmentTestResultService(IGenericRepository<Models.AppointmentTestResult> repository, DataContext context) : GenericService<CreateAppointmentTestResult, UpdateAppointmentTestResult, Models.AppointmentTestResult>(repository), IAppointmentTestResultService
    {
        private readonly DataContext _context = context;

        public async override Task<ServiceResult<List<Models.AppointmentTestResult>>> GetAll()
        {
            try
            {
                var results = await _context.AppointmentTestResults.Include(a => a.AppointmentTest).ThenInclude(a => a.Test).ToListAsync();
                return new ServiceResult<List<Models.AppointmentTestResult>>
                {
                    Success = true,
                    StatusCode = 200,
                    Data = results,
                    Message = "Success"
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.AppointmentTestResult>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
