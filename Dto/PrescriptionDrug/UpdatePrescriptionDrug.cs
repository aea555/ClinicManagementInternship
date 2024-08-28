using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.PrescriptionDrug
{
    public class UpdatePrescriptionDrug : GenericUpdateDTO
    {
        [ValidEntityId<Models.Drug>("Drugs")]
        public int? DrugId { get; set; }
    }
}
