using ClinicManagementInternship.Dto.PrescriptionDrug;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.PrescriptionDrug
{
    public class PrescriptionDrugService(IGenericRepository<Models.PrescriptionDrug> repository) : GenericService<CreatePrescriptionDrug, UpdatePrescriptionDrug, Models.PrescriptionDrug>(repository), IPrescritpionDrugService
    {
    }
}
