using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Test
{
    public class UpdateTest : GenericUpdateDTO
    {
        public string? Name { get; set; }
        public string? UnitType { get; set; }
        public decimal? RangeStart { get; set; }
        public decimal? RangeEnd { get; set; }
        public string? Desc { get; set; }
    }
}
