using ClinicManagementInternship.Dto.Admin;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Admin
{
    public interface IAdminService : IGenericService<CreateAdmin, UpdateAdmin, Models.Admin>
    {
    }
}
