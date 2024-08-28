using ClinicManagementInternship.Dto.Drug;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Drug
{
    public class DrugService(IGenericRepository<Models.Drug> repository) : GenericService<CreateDrug, UpdateDrug, Models.Drug>(repository), IDrugService
    {
    }
}
