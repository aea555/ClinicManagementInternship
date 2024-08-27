using ClinicManagementInternship.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string PasswordHash { get; set; }
        public required AccountRole Role { get; set; } = AccountRole.NONE;
    }
}
