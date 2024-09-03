using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Biochemist;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Biochemist
{
    public class BiochemistService(IGenericRepository<Models.Biochemist> repository, DataContext context) : GenericService<CreateBiochemist, UpdateBiochemist, Models.Biochemist>(repository), IBiochemistService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Biochemist>> CreateNew(CreateBiochemist CreateDto)
        {
            var account = await _context.Accounts.FindAsync(CreateDto.AccountId);
            if (account is not null)
            {
                bool isPatient = await _context.Patients.AnyAsync(p => p.AccountId == CreateDto.AccountId);
                bool isDoctor = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);
                bool isBiochemist = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);

                if (isPatient || isDoctor || isBiochemist)
                {
                    return new ServiceResult<Models.Biochemist>
                    {
                        Success = false,
                        ErrorMessage = "User is already registered as a patient, doctor or biochemist!",
                        StatusCode = 400
                    };
                }

                account.Role = Enums.AccountRole.BIOCHEMIST;
                await _context.SaveChangesAsync();
                return await base.CreateNew(CreateDto);
            }
            else
            {
                return new ServiceResult<Models.Biochemist>
                {
                    Success = false,
                    ErrorMessage = "Account doesn't exist.",
                    StatusCode = 400
                };
            }
        }
    }
}
