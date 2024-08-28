using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Biochemist
{
    public class CreateBiochemist : GenericDTO
    {
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
