using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Account
{
    public class GetRequestAccountId : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        public required int AccountId { get; set; }
    }
}
