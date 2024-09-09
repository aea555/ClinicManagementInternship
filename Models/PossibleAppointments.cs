namespace ClinicManagementInternship.Models
{
    public class PossibleAppointments
    {
        public required int ClinicId { get; set; }
        public required int DoctorId { get; set; }
        public required string DoctorFirstName { get; set; }
        public required string DoctorLastName { get; set; }
        public required string ClinicName { get; set; }
        public required DateTime StartTime { get; set; }
    }
}
