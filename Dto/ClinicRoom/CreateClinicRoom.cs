using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.ClinicRoom
{
    public class CreateClinicRoom : GenericDTO
    {
        public required int ClinicId { get; set; }
        public required int Number { get; set; }
    }
}
