using ClinicManagementInternship.Enums;
using System.Text.Json.Serialization;

namespace ClinicManagementInternship.Models
{
    public class BiochemistSignupRequest : ModelBase
    {
        public required int AccountId { get; set; }
        [JsonIgnore]
        public Account? Account { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required SignUpRequestStatus SignUpRequest { get; set; } = SignUpRequestStatus.PENDING;
    }
}
