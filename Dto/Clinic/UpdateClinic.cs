using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Clinic
{
    public class UpdateClinic : GenericUpdateDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public int? OpenTime { get; set; }
        public int? CloseTime { get; set; }
        public int? BreakStartTime { get; set; }
        public int? BreakEndTime { get; set; }
    }
}
