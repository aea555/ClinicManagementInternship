using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Admin
{
    public class AdminService(IGenericRepository<Models.Admin> repository) : GenericService<CreateAdmin, UpdateAdmin, Models.Admin>(repository), IAdminService
    {
    }
}
