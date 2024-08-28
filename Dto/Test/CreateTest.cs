using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Test
{
    public class CreateTest : GenericDTO
    {
        public required string Name { get; set; }
        public required string UnitType { get; set; }
        public required decimal RangeStart { get; set; }
        public required decimal RangeEnd { get; set; }
        public string? Desc { get; set; }
    }
}
