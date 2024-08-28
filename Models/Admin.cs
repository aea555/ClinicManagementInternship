using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Admin
    {
        [Key]
        public int Id { get; set; }
        public required int AccountId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
