using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Admin
{
    public class UpdateAdmin : GenericUpdateDTO
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
    }
}
