using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.PrescriptionDrug
{
    public class CreatePrescriptionDrug : GenericDTO
    {
        [ValidEntityId<Models.Drug>("Drugs")]
        public required int DrugId { get; set; }
        [ValidEntityId<Models.Prescription>("Prescriptions")]
        public required int PrescriptionId { get; set; }
    }
}
