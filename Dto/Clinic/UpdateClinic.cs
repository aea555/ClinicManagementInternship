using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Clinic
{
    public class UpdateClinic : GenericUpdateDTO
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public TimeOnly? OpenTime { get; set; }
        public TimeOnly? CloseTime { get; set; }
        public TimeOnly? BreakStartTime { get; set; }
        public TimeOnly? BreakEndTime { get; set; }
    }
}
