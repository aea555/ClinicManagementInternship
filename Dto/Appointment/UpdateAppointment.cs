using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Appointment
{
    public class UpdateAppointment : GenericUpdateDTO
    {
        public DateTime? CompleteTime { get; set; }
        public string? Notes { get; set; }
        public AppointmentStatus? AppointmentStatus { get; set; }
    }
}
