using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Feedback
{
    public class UpdateFeedback : GenericUpdateDTO
    {
        public int? Rating { get; set; }
        public string? Comment { get; set; }
        public bool? Deleted { get; set; }
    }
}
