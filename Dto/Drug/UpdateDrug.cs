using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Drug
{
    public class UpdateDrug : GenericUpdateDTO
    {
        public required string Name { get; set; }
    }
}
