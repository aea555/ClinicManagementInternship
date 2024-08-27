using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class AppointmentTest
    {
        [Key]
        public int Id { get; set; }
        public required int AppointmentId { get; set; }
        public Appointment? Appointment { get; set; }
        public required int TestId { get; set; }
        public Test? Test { get; set; }
    }
}
