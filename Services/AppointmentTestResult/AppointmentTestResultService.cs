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

        public async Task<ServiceResult<Models.AppointmentTestResult>> CreateWithAccountId(CreateAppointmentTestResultAccountId CreateDto)
        {
            try
            {
                var biochemist = await _context.Biochemists.FirstOrDefaultAsync(p => p.AccountId == CreateDto.AccountId);
                if (biochemist is null)
                {
                    return new ServiceResult<Models.AppointmentTestResult>
                    {
                        Success = false,
                        ErrorMessage = "No such biochemist",
                        StatusCode = 400
                    };
                }

                var newAppointmentTestResult = new Models.AppointmentTestResult
                {
                    AppointmentTestId = CreateDto.AppointmentTestId,
                    BiochemistId = biochemist.Id,
                    ResultFlag = CreateDto.ResultFlag,
                    Value = CreateDto.Value,
                    ResultDate = DateTime.UtcNow
                };

                var result = await _context.AppointmentTestResults.AddAsync(newAppointmentTestResult);
                await _context.SaveChangesAsync();

                return new ServiceResult<Models.AppointmentTestResult>
                {
                    Success = true,
                    Data = newAppointmentTestResult,
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                return new ServiceResult<Models.AppointmentTestResult>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
