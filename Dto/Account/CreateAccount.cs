using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Account
{
    public class CreateAccount : GenericDTO
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
    }
}
