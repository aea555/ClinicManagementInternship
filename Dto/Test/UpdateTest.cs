using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Test
{
    public class UpdateTest : GenericUpdateDTO
    {
        public string? Name { get; set; }
        public string? UnitType { get; set; }
        public decimal? RangeStartMale { get; set; }
        public decimal? RangeEndMale { get; set; }
        public decimal? RangeStartFemale { get; set; }
        public decimal? RangeEndFemale { get; set; }
        public string? Desc { get; set; }
    }
}
