using ClinicManagementInternship.Data;
using ClinicManagementInternship.Dto.Appointment;
using ClinicManagementInternship.Models;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Services.Appointment
{
    public class AppointmentService(IGenericRepository<Models.Appointment> repository, DataContext context) : GenericService<CreateAppointment, UpdateAppointment, Models.Appointment>(repository), IAppointmentService
    {
        private readonly DataContext _context = context;
        private readonly IGenericRepository<Models.Appointment> _repository = repository;

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

        public async Task<ServiceResult<List<Models.PossibleAppointments>>> GetFreeAppointmentsOfToday(int clinicId)
        {
            try
            {
                var clinic = await _context.Clinics.FindAsync(clinicId);

                if (clinic is null)
                {
                    return new ServiceResult<List<Models.PossibleAppointments>>
                    {
                        Success = false,
                        ErrorMessage = "Clinic doesn't exist.",
                        StatusCode = 400
                    };
                }

                var doctors = await _context.Doctors.Where(d => d.ClinicId == clinic.Id).ToListAsync();

                if (doctors is null)
                {
                    return new ServiceResult<List<Models.PossibleAppointments>>
                    {
                        Success = false,
                        ErrorMessage = "No doctors in clinic",
                        StatusCode = 400
                    };
                }

                List<PossibleAppointments> possibleAppointments = [];
                DateTime today = DateTime.Today;
                await GenerateAppointmentSlots(clinic, clinic.OpenTime, clinic.BreakStartTime, today, possibleAppointments, doctors);
                await GenerateAppointmentSlots(clinic, clinic.BreakEndTime, clinic.CloseTime, today, possibleAppointments, doctors);

                return new ServiceResult<List<Models.PossibleAppointments>>
                {
                    Success = true,
                    Message = "Possible Appointments",
                    Data = possibleAppointments,
                    StatusCode = 200
                };

            }
            catch (Exception e)
            {
                return new ServiceResult<List<Models.PossibleAppointments>>
                {
                    Success = false,
                    ErrorMessage = "An unexpected error occurred.",
                    StatusCode = 500
                };
            }
        }

        private async Task GenerateAppointmentSlots(Models.Clinic clinic, TimeOnly sessionStartTime, TimeOnly sessionEndTime, DateTime today, List<PossibleAppointments> possibleAppointments, List<Models.Doctor> doctors)
        {
            DateTime sessionStart = DateTime.SpecifyKind(today.Add(sessionStartTime.ToTimeSpan()), DateTimeKind.Local).ToUniversalTime();
            DateTime sessionEnd = DateTime.SpecifyKind(today.Add(sessionEndTime.ToTimeSpan()), DateTimeKind.Local).ToUniversalTime();

            DateTime nowUtc = DateTime.UtcNow;

            foreach (var doctor in doctors)
            {
                for (DateTime slot = sessionStart; slot < sessionEnd; slot = slot.AddMinutes(10))
                {
                    if (slot < nowUtc)
                    {
                        continue;
                    }

                    var existingAppointment = await _context.Appointments
                        .Include(i => i.Doctor)
                        .Include(i => i.Clinic)
                        .FirstOrDefaultAsync(a => a.StartTime == slot && a.DoctorId == doctor.Id);

                    if (existingAppointment is null)
                    {
                        possibleAppointments.Add(new PossibleAppointments
                        {
                            StartTime = slot,
                            ClinicId = clinic.Id,
                            ClinicName = clinic.Name,
                            DoctorId = doctor.Id,
                            DoctorFirstName = doctor.FirstName,
                            DoctorLastName = doctor.LastName
                        });
                    }
                }
            }
        }

        public async Task<ServiceResult<Models.Appointment>> CreateWithAccountId(CreateAppointmentAccountId CreateDto)
        {
            try
            {
                var existingAccount = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == CreateDto.AccountId);
                if (existingAccount is null)
                {
                    return new ServiceResult<Models.Appointment>
                    {
                        Success = false,
                        ErrorMessage = "No such account",
                        StatusCode = 400
                    };
                }

                var patient = await _context.Patients.FirstOrDefaultAsync(p => p.AccountId == CreateDto.AccountId);
                if (patient is null)
                {
                    return new ServiceResult<Models.Appointment>
                    {
                        Success = false,
                        ErrorMessage = "No such patient",
                        StatusCode = 400
                    };
                }

                var newAppointment = new Models.Appointment
                {
                    DoctorId = CreateDto.DoctorId,
                    ClinicId = CreateDto.ClinicId,
                    PatientId = patient.Id,
                    StartTime = CreateDto.StartTime
                };

                var result = await _context.Appointments.AddAsync(newAppointment);
                await _context.SaveChangesAsync();

                return new ServiceResult<Models.Appointment>
                {
                    Success = true,
                    Data = newAppointment,
                    StatusCode = 200
                };
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

