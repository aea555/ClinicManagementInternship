using ClinicManagementInternship.Models;
using dotenv.net;
using Microsoft.EntityFrameworkCore;

namespace ClinicManagementInternship.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                DotEnv.Load();
                optionsBuilder.UseNpgsql(Environment.GetEnvironmentVariable("DB_STRING"), options =>
                {
                    options.EnableRetryOnFailure();
                });
            }
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<AppointmentTest> AppointmentTests { get; set; }
        public DbSet<AppointmentTestResult> AppointmentTestResults { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Biochemist> Biochemists { get; set; }
        public DbSet<BiochemistSignupRequest> BiochemistSignupRequests { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<ClinicRoom> ClinicRooms { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<DoctorSignupRequest> DoctorSignupRequests { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Injection> Injections { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDrug> PrescriptionDrugs { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<SignupConfirmation> SignupConfirmations { get; set; }
    }
}
