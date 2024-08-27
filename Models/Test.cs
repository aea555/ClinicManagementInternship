using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Test
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string UnitType { get; set; }
        public required decimal RangeStart { get; set; }
        public required decimal RangeEnd { get; set; }
        public string? Desc { get; set; }
    }
}
