using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Patient;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Patient
{
    public class PatientService(IGenericRepository<Models.Patient> repository, DataContext context) : GenericService<CreatePatient, UpdatePatient, Models.Patient>(repository), IPatientService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Patient>> CreateNew(CreatePatient createDto)
        {
            try
            {
                var account = await _context.Accounts.FindAsync(createDto.AccountId);
                if (account is null)
                {
                    return new ServiceResult<Models.Patient>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist",
                        StatusCode = 400
                    };
                }
                bool isPatient = await _context.Patients.AnyAsync(p => p.AccountId == createDto.AccountId);
                bool isDoctor = await _context.Biochemists.AnyAsync(d => d.AccountId == createDto.AccountId);
                bool isBiochemist = await _context.Biochemists.AnyAsync(d => d.AccountId == createDto.AccountId);
                bool isAdmin = await _context.Admins.AnyAsync(d => d.AccountId == createDto.AccountId);

                if (isPatient || isDoctor || isBiochemist || isAdmin)
                {
                    return new ServiceResult<Models.Patient>
                    {
                        Success = false,
                        ErrorMessage = "User is already registered as a patient, doctor or biochemist!",
                        StatusCode = 400
                    };
                }

                var patient = await base.CreateNew(createDto);
                account.Role = Enums.AccountRole.PATIENT;
                await _context.SaveChangesAsync();

                return patient;
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Patient>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
