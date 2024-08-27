using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public class Biochemist
    {
        [Key]
        public int Id { get; set; }
        public required int AccountId { get; set; }
        public Account? Account { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
