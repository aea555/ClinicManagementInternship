using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Prescription
{
    public class PrescriptionService(IGenericRepository<Models.Prescription> repository, DataContext context) : GenericService<CreatePrescription, UpdatePrescription, Models.Prescription>(repository), IPrescriptionService
    {
        private readonly DataContext _context = context;

        public async Task<ServiceResult<Models.Prescription>> CreateWithAccountId(CreatePrescriptionAccountId CreateDto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == CreateDto.AccountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<Models.Prescription>
                    {
                        Success = false,
                        ErrorMessage = "No such account",
                        StatusCode = 400
                    };
                }

                var doctor = await _context.Doctors.FirstOrDefaultAsync(d => d.AccountId == CreateDto.AccountId);
                if (doctor is null)
                {
                    return new ServiceResult<Models.Prescription>
                    {
                        Success = false,
                        ErrorMessage = "No such doctor",
                        StatusCode = 400
                    };
                }

                var prescription = new Models.Prescription
                {
                    AppointmentId = CreateDto.AppointmentId,
                    DoctorId = doctor.Id,
                    DurationDays = CreateDto.DurationDays,
                    PatientId = CreateDto.PatientId,
                };

                var result = await _context.Prescriptions.AddAsync(prescription);
                await _context.SaveChangesAsync();

                return new ServiceResult<Models.Prescription>
                {
                    Success = true,
                    Data = prescription,
                    StatusCode = 200
                };
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Prescription>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }
    }
}
