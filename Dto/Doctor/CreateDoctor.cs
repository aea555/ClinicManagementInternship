using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Doctor
{
    public class CreateDoctor : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        [ValidEntityId<Models.Clinic>("Clinics")]
        public required int ClinicId { get; set; }
        [ValidEntityId<Models.ClinicRoom>("ClinicRooms")]
        public required int ClinicRoomId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
