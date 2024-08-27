using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Drug
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
    }
}
