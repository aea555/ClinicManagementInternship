using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class ClinicRoom
    {
        [Key]
        public int Id { get; set; }
        public required int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public required int Number { get; set; }
    }
}
