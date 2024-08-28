using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Biochemist
{
    public class UpdateBiochemist : GenericUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
