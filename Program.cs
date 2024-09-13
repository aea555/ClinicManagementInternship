using ClinicManagementInternship.Data;
using ClinicManagementInternship.Models;
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
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Threading.RateLimiting;

DotEnv.Load();
var builder = WebApplication.CreateBuilder(args);

//Repos
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IGenericRepository<Account>, GenericRepository<Account>>();
builder.Services.AddScoped<IGenericRepository<Admin>, GenericRepository<Admin>>();
builder.Services.AddScoped<IGenericRepository<Appointment>, GenericRepository<Appointment>>();
builder.Services.AddScoped<IGenericRepository<AppointmentTest>, GenericRepository<AppointmentTest>>();
builder.Services.AddScoped<IGenericRepository<AppointmentTestResult>, GenericRepository<AppointmentTestResult>>();
builder.Services.AddScoped<IGenericRepository<Biochemist>, GenericRepository<Biochemist>>();
builder.Services.AddScoped<IGenericRepository<BiochemistSignupRequest>, GenericRepository<BiochemistSignupRequest>>();
builder.Services.AddScoped<IGenericRepository<Clinic>, GenericRepository<Clinic>>();
builder.Services.AddScoped<IGenericRepository<ClinicRoom>, GenericRepository<ClinicRoom>>();
builder.Services.AddScoped<IGenericRepository<Doctor>, GenericRepository<Doctor>>();
builder.Services.AddScoped<IGenericRepository<DoctorSignupRequest>, GenericRepository<DoctorSignupRequest>>();
builder.Services.AddScoped<IGenericRepository<Drug>, GenericRepository<Drug>>();
builder.Services.AddScoped<IGenericRepository<Feedback>, GenericRepository<Feedback>>();
builder.Services.AddScoped<IGenericRepository<Injection>, GenericRepository<Injection>>();
builder.Services.AddScoped<IGenericRepository<Patient>, GenericRepository<Patient>>();
builder.Services.AddScoped<IGenericRepository<Prescription>, GenericRepository<Prescription>>();
builder.Services.AddScoped<IGenericRepository<PrescriptionDrug>, GenericRepository<PrescriptionDrug>>();
builder.Services.AddScoped<IGenericRepository<Test>, GenericRepository<Test>>();


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

builder.Logging.AddConsole();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();
builder.Services.AddRateLimiter(options =>
{
    options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(context =>
    {
        var xForwardedForHeader = context.Request.Headers["X-Forwarded-For"].ToString();
        var ipAddress = !string.IsNullOrEmpty(xForwardedForHeader)
            ? xForwardedForHeader.Split(',').FirstOrDefault()?.Trim()
            : context.Connection.RemoteIpAddress?.ToString() ?? "unknown";

        Console.WriteLine($"IP: {ipAddress} - Rate Limiting Applied");

        return RateLimitPartition.GetSlidingWindowLimiter(
            ipAddress,
            _ => new SlidingWindowRateLimiterOptions
            {
                PermitLimit = 100,
                Window = TimeSpan.FromMinutes(1),
                SegmentsPerWindow = 12,
            });
    });
    options.RejectionStatusCode = 429;
});


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

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseRateLimiter();

app.MapControllers();

app.Run();

app.Use(async (context, next) =>
{
    Console.WriteLine($"Incoming request from IP: {context.Request.Headers["X-Forwarded-For"]} - {context.Connection.RemoteIpAddress}");
    await next();
});
