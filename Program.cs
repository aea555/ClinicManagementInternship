using ClinicManagementInternship.Data;
using ClinicManagementInternship.Services.Account;
using ClinicManagementInternship.Services.Admin;
using ClinicManagementInternship.Services.Appointment;
using ClinicManagementInternship.Services.AppointmentTest;
using ClinicManagementInternship.Services.AppointmentTestResult;
using ClinicManagementInternship.Services.Biochemist;
using ClinicManagementInternship.Services.BiochemistSignupRequest;
using ClinicManagementInternship.Services.Clinic;
using ClinicManagementInternship.Services.ClinicRoom;
using ClinicManagementInternship.Services.Doctor;
using ClinicManagementInternship.Services.DoctorSignupRequest;
using ClinicManagementInternship.Services.Drug;
using ClinicManagementInternship.Services.Feedback;
using ClinicManagementInternship.Services.Injection;
using ClinicManagementInternship.Services.Patient;
using ClinicManagementInternship.Services.Prescription;
using ClinicManagementInternship.Services.PrescriptionDrug;
using ClinicManagementInternship.Services.Test;
using ClinicManagementInternship.Templates;
using dotenv.net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

//Repo
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

//Services
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<IAppointmentService, AppointmentService>();
builder.Services.AddScoped<IAppointmentTestService, AppointmentTestService>();
builder.Services.AddScoped<IAppointmentTestResultService, AppointmentTestResultService>();
builder.Services.AddScoped<IBiochemistService, BiochemistService>();
builder.Services.AddScoped<IBiochemistSignupRequestService, BiochemistSignupRequestService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<IClinicRoomService, ClinicRoomService>();
builder.Services.AddScoped<IDoctorService, DoctorService>();
builder.Services.AddScoped<IDoctorSignupRequestService, DoctorSignupRequestService>();
builder.Services.AddScoped<IDrugService, DrugService>();
builder.Services.AddScoped<IFeedbackService, FeedbackService>();
builder.Services.AddScoped<IInjectionService, InjectionService>();
builder.Services.AddScoped<IPatientService, PatientService>();
builder.Services.AddScoped<IPrescriptionService, PrescriptionService>();
builder.Services.AddScoped<IPrescriptionDrugService, PrescriptionDrugService>();
builder.Services.AddScoped<ITestService, TestService>();


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = Environment.GetEnvironmentVariable("JWT_ISSUER"),
        ValidAudience = Environment.GetEnvironmentVariable("JWT_AUDIENCE"),
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("JWT_KEY"))),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(builder =>
{
    builder.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
