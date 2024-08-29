using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Doctor;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Doctor
{
    public class DoctorService(IGenericRepository<Models.Doctor> repository, DataContext context) : GenericService<CreateDoctor, UpdateDoctor, Models.Doctor>(repository), IDoctorService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Doctor>> CreateNew(CreateDoctor CreateDto)
        {
            var account = await _context.Accounts.FindAsync(CreateDto.AccountId);
            if (account is not null)
            {
                bool isPatient = await _context.Patients.AnyAsync(p => p.AccountId == CreateDto.AccountId);
                bool isDoctor = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);
                bool isBiochemist = await _context.Biochemists.AnyAsync(d => d.AccountId == CreateDto.AccountId);

                if (isPatient || isDoctor || isBiochemist)
                {
                    return new ServiceResult<Models.Doctor>
                    {
                        Success = false,
                        ErrorMessage = "User is already registered as a patient, doctor or biochemist!",
                        StatusCode = 400
                    };
                }

                return await base.CreateNew(CreateDto);
            }
            else
            {
                return new ServiceResult<Models.Doctor>
                {
                    Success = false,
                    ErrorMessage = "Account doesn't exist.",
                    StatusCode = 400
                };
            }
        }

        public async Task<ServiceResult<Models.Doctor>> UpdateDoctorName(int id, string FirstName, string LastName)
        {
            try
            {
                var existingDoctor = await _context.Doctors.FindAsync(id);
                if (existingDoctor is not null)
                {
                    existingDoctor.FirstName = FirstName ?? existingDoctor.FirstName;
                    existingDoctor.LastName = LastName ?? existingDoctor.LastName;
                    await _context.SaveChangesAsync();
                    return new ServiceResult<Models.Doctor>
                    {
                        Success = true,
                        StatusCode = 200,
                        Message = "Doctor name updated."
                    };
                }
                else
                {
                    return new ServiceResult<Models.Doctor>
                    {
                        Success = false,
                        ErrorMessage = "Doctor doesn't exist.",
                        StatusCode = 400
                    };
                }
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Doctor>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}


