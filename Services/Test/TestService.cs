using ClinicManagementInternship.Dto.Test;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Test
{
    public class TestService(IGenericRepository<Models.Test> repository) : GenericService<CreateTest, UpdateTest, Models.Test>(repository), ITestService
    {
    }
}
