using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Doctor
{
    public class CreateDoctor : GenericDTO
    {
        public required int AccountId { get; set; }
        public required int ClinicId { get; set; }
        public required int ClinicRoomId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
