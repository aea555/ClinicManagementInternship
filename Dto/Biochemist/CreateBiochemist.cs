using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.Biochemist
{
    public class CreateBiochemist : GenericDTO
    {
        [ValidEntityId<Models.Account>("Accounts")]
        [UniqueAccountIdValidation]
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
