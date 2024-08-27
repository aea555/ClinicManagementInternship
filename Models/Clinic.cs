using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Clinic
    {
        [Key]
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required int OpenTime { get; set; }
        public required int CloseTime { get; set; }
        public required int BreakStartTime { get; set; }
        public required int BreakEndTime { get; set; }
    }
}
