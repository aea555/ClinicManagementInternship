using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class PrescriptionDrug
    {
        [Key]
        public int Id { get; set; }
        public required int DrugId { get; set; }
        public Drug? Drug { get; set; }
        public required int PrescriptionId { get; set; }
        public Prescription? Prescription { get; set; }
    }
}
