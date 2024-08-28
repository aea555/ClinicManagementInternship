using ClinicManagementInternship.Dto.Drug;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Drug
{
    public interface IDrugService : IGenericService<CreateDrug, UpdateDrug, Models.Drug>
    {
    }
}
