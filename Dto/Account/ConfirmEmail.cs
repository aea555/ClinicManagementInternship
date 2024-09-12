using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Account
{
    public class ConfirmEmail : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
        public required string Email { get; set; }
    }
}
