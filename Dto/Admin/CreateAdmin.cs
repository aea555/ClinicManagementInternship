using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Admin
{
    public class CreateAdmin : GenericDTO
    {
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
