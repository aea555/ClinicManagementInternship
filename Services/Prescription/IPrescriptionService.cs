using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Services.Prescription
{
    public interface IPrescriptionService : IGenericService<CreatePrescription, UpdatePrescription, Models.Prescription>
    {
        Task<ServiceResult<Models.Prescription>> CreateWithAccountId(CreatePrescriptionAccountId CreateDto);
    }
}
