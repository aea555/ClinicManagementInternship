using ClinicManagementInternship.Dto.AppointmentTest;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.AppointmentTest
{
    public class AppointmentTestService(IGenericRepository<Models.AppointmentTest> repository) : GenericService<CreateAppointmentTest, UpdateAppointmentTest, Models.AppointmentTest>(repository), IAppointmentTestService
    {
    }
}
