using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Injection
    {
        [Key]
        public int Id { get; set; }
        public required int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public required int DoctorId { get; set; }
        public Doctor? Doctor { get; set; }
        public required int DrugId { get; set; }
        public Drug? Drug { get; set; }
    }
}
