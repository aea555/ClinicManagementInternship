using ClinicManagementInternship.Enums;

namespace ClinicManagementInternship.Models
{
    public class Account : ModelBase
    {
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required GenderEnum Gender { get; set; }
        public required DateTime BirthDate { get; set; }
        public required AccountRole Role { get; set; } = AccountRole.NONE;
    }
}
