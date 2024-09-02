using ClinicManagementInternship.Enums;
using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Account
{
    public class UpdateAccount : GenericUpdateDTO
    {
        public string? Email { get; set; }
        public string? PasswordHash { get; set; }
        public GenderEnum? Gender { get; set; }
        public DateTime? BirthDate { get; set; }
    }
}
