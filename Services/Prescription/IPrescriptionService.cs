using ClinicManagementInternship.Dto.Prescription;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Services.Prescription
{
    public interface IPrescriptionService : IGenericService<CreatePrescription, UpdatePrescription, Models.Prescription>
    {
    }
}
