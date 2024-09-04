using System.ComponentModel.DataAnnotations;

namespace ClinicManagementInternship.Models
{
    public abstract class ModelBase
    {
        [Key]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
