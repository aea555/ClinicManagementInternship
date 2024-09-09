using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Account;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Account
{
    public class AccountService(IGenericRepository<Models.Account> repository, DataContext context) : GenericService<CreateAccount, UpdateAccount, Models.Account>(repository), IAccountService
    {
        private readonly DataContext _context = context;

        public override async Task<ServiceResult<Models.Account>> CreateNew(CreateAccount CreateDto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == CreateDto.Email);
                if (existingAccount is not null)
                {
                    return new ServiceResult<Models.Account>
                    {
                        Success = false,
                        ErrorMessage = "Email is already used.",
                        StatusCode = 400
                    };
                }
                string HashedPassword = PasswordHash.CreatePasswordHash(CreateDto.PasswordHash);
                CreateDto.PasswordHash = HashedPassword;
                var account = await base.CreateNew(CreateDto);

                var returnObj = account.Data;
                returnObj.PasswordHash = "";

                return new ServiceResult<Models.Account>
                {
                    Success = true,
                    Data = returnObj,
                    StatusCode = 201
                };
            }
            catch (Exception)
            {
                return new ServiceResult<Models.Account>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<SignupRequestsResult>> GetRequestsOfAccount(GetRequestAccountId dto)
        {
            try
            {
                var requestsDoctor = await _context.DoctorSignupRequests.FirstOrDefaultAsync(dsr => dsr.AccountId == dto.AccountId &&
                (dsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING || dsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED));

                var requestsBiochemist = await _context.BiochemistSignupRequests.FirstOrDefaultAsync(bsr => bsr.AccountId == dto.AccountId &&
                (bsr.SignUpRequest == Enums.SignUpRequestStatus.PENDING || bsr.SignUpRequest == Enums.SignUpRequestStatus.ACCEPTED));

                var returnObj = new SignupRequestsResult
                {
                    DoctorSignupRequest = requestsDoctor,
                    BiochemistSignupRequest = requestsBiochemist
                };

                return new ServiceResult<SignupRequestsResult>
                {
                    Success = true,
                    Message = "Records found",
                    Data = returnObj,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<SignupRequestsResult>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<List<Models.Appointment>>> GetAppointmentsOfAccount(int accountId)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<List<Models.Appointment>>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId == accountId);

                if (patient is null)
                {
                    return new ServiceResult<List<Models.Appointment>>
                    {
                        Success = false,
                        ErrorMessage = "Account is not signed up as a patient.",
                        StatusCode = 400
                    };
                }

                var userAppointments = await _context.Appointments.Include(a => a.Clinic).Include(a => a.Doctor)
                    .Where(a => a.PatientId == patient.Id && !a.IsDeleted)
                    .Select
                    (
                        a => new
                        {
                            a.Id,
                            a.AppointmentStatus,
                            a.Clinic.Name,
                            a.Doctor.FirstName,
                            a.Doctor.LastName,
                            a.CreatedAt,
                            a.FinishTime,
                            a.StartTime
                        }
                    )
                    .ToListAsync();


                return new ServiceResult<List<Models.Appointment>>
                {
                    Success = true,
                    Message = "Appointments found",
                    ExtraData = userAppointments,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.Appointment>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<List<Models.Prescription>>> GetPrescriptionsOfAccount(int accountId)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<List<Models.Prescription>>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId == accountId);

                if (patient is null)
                {
                    return new ServiceResult<List<Models.Prescription>>
                    {
                        Success = false,
                        ErrorMessage = "Account is not signed up as a patient.",
                        StatusCode = 400
                    };
                }

                var userPrescriptions = await _context.PrescriptionDrugs.Include(pd => pd.Drug).Include(p => p.Prescription).ThenInclude(p => p.Doctor)
                    .Where(pd => pd.Prescription.PatientId == patient.Id)
                    .Select
                    (
                        pd => new
                        {
                            pd.Id,
                            pd.CreatedAt,
                            pd.Drug.Name,
                            pd.Prescription.DurationDays,
                            pd.PrescriptionId,
                            pd.DrugId,
                            pd.Prescription.Doctor.FirstName,
                            pd.Prescription.Doctor.LastName,
                            pd.Prescription.DoctorId,
                        }
                    )
                    .ToListAsync();

                return new ServiceResult<List<Models.Prescription>>
                {
                    Success = true,
                    Message = "Prescriptions found",
                    ExtraData = userPrescriptions,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.Prescription>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<List<Models.Injection>>> GetInjectionsOfAccount(int accountId)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<List<Models.Injection>>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId == accountId);

                if (patient is null)
                {
                    return new ServiceResult<List<Models.Injection>>
                    {
                        Success = false,
                        ErrorMessage = "Account is not signed up as a patient.",
                        StatusCode = 400
                    };
                }

                var userInjections = await _context.Injections.Include(i => i.Doctor).Include(i => i.Drug)
                    .Where(i => i.PatientId == patient.Id)
                    .Select
                    (
                        i => new
                        {
                            i.Id,
                            i.CreatedAt,
                            i.DoctorId,
                            i.Doctor.FirstName,
                            i.Doctor.LastName,
                            i.DrugId,
                            i.Drug.Name,
                            i.IsDeleted
                        }
                    )
                    .ToListAsync();

                return new ServiceResult<List<Models.Injection>>
                {
                    Success = true,
                    Message = "Injection found",
                    ExtraData = userInjections,
                    StatusCode = 400
                };
            }
            catch (Exception)
            {
                return new ServiceResult<List<Models.Injection>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        public async Task<ServiceResult<List<Models.AppointmentTestResult>>> GetTestResultsOfAccount(int accountId)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<List<Models.AppointmentTestResult>>
                    {
                        Success = false,
                        ErrorMessage = "Account doesn't exist.",
                        StatusCode = 400
                    };
                }

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId == accountId);

                if (patient is null)
                {
                    return new ServiceResult<List<Models.AppointmentTestResult>>
                    {
                        Success = false,
                        ErrorMessage = "Account is not signed up as a patient.",
                        StatusCode = 400
                    };
                }

                var userTestResults = await _context.AppointmentTestResults.Include(atr => atr.Biochemist).Include(atr => atr.AppointmentTest)
                    .ThenInclude(at => at.Appointment).ThenInclude(a => a.Doctor)
                    .Include(atr => atr.AppointmentTest).ThenInclude(at => at.Test)
                    .Where(atr => atr.AppointmentTest.Appointment.PatientId == patient.Id)
                    .Select
                    (
                        atr => new
                        {
                            atr.Id,
                            atr.Value,
                            atr.ResultDate,
                            atr.ResultFlag,
                            atr.BiochemistId,
                            BiochemistFirstName = atr.Biochemist.FirstName,
                            BiochemistLastName = atr.Biochemist.LastName,
                            DoctorFirstName = atr.AppointmentTest.Appointment.Doctor.FirstName,
                            DoctorLastName = atr.AppointmentTest.Appointment.Doctor.LastName,
                            atr.AppointmentTest.Appointment.DoctorId,
                            atr.AppointmentTest.Test.Name,
                            atr.AppointmentTest.Test.UnitType,
                            atr.AppointmentTest.TestId,
                            atr.CreatedAt
                        }
                    )
                    .ToListAsync();

                return new ServiceResult<List<Models.AppointmentTestResult>>
                {
                    Success = true,
                    Message = "Test Results found",
                    ExtraData = userTestResults,
                    StatusCode = 400
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
