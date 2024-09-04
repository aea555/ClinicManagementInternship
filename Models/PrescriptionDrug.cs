namespace ClinicManagementInternship.Models
{
    public class PrescriptionDrug : ModelBase
    {
        public required int DrugId { get; set; }
        public Drug? Drug { get; set; }
        public required int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
