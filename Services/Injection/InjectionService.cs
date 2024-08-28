using ClinicManagementInternship.Dto.Injection;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Injection
{
    public class InjectionService(IGenericRepository<Models.Injection> repository) : GenericService<CreateInjection, UpdateInjection, Models.Injection>(repository), IInjectionService
    {
    }
}
