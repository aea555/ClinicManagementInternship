using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Prescription
{
    public class PrescriptionService(IGenericRepository<Models.Prescription> repository) : GenericService<CreatePrescription, UpdatePrescription, Models.Prescription>(repository), IPrescriptionService
    {
    }
}
