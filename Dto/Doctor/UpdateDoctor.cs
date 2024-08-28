using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Doctor
{
    public class UpdateDoctor : GenericUpdateDTO
    {
        public int? ClinicId { get; set; }
        public int? ClinicRoomId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
