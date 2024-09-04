using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Test
{
    public class CreateTest : GenericDTO
    {
        public required string Name { get; set; }
        public required string UnitType { get; set; }
        public required decimal RangeStartMale { get; set; }
        public required decimal RangeEndMale { get; set; }
        public required decimal RangeStartFemale { get; set; }
        public required decimal RangeEndFemale { get; set; }
        public string? Desc { get; set; }
    }
}
