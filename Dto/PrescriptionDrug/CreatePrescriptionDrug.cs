using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.PrescriptionDrug
{
    public class CreatePrescriptionDrug : GenericDTO
    {
        public required int DrugId { get; set; }
        public required int PrescriptionId { get; set; }
    }
}
