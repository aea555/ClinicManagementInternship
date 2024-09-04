namespace ClinicManagementInternship.Models
{
    public class Clinic : ModelBase
    {
        public required string Name { get; set; }
        public required string Address { get; set; }
        public required TimeOnly OpenTime { get; set; }
        public required TimeOnly CloseTime { get; set; }
        public required TimeOnly BreakStartTime { get; set; }
        public required TimeOnly BreakEndTime { get; set; }
    }
}
