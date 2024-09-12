using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Account
{
    public class ConfirmPassword : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        public required string Password { get; set; }
    }
}
