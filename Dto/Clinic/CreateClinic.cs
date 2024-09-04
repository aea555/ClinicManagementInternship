using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Clinic
{
    public class CreateClinic : GenericDTO
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required TimeOnly OpenTime { get; set; }
        public required TimeOnly CloseTime { get; set; }
        public required TimeOnly BreakStartTime { get; set; }
        public required TimeOnly BreakEndTime { get; set; }
    }
}
