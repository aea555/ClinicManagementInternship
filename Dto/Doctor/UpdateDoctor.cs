using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Doctor
{
    public class UpdateDoctor : GenericUpdateDTO
    {
        [ValidEntityId<Models.Appointment>("Clinics", isRequired: false)]
        public int? ClinicId { get; set; }
        [ValidEntityId<Models.Appointment>("ClinicRooms", isRequired: false)]
        public int? ClinicRoomId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
