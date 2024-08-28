using ClinicManagementInternship.Templates;
using ClinicManagementInternship.Utils;

namespace ClinicManagementInternship.Dto.ClinicRoom
{
    public class CreateClinicRoom : GenericDTO
    {
        [ValidEntityId<Models.Clinic>("Clinics")]
        public required int ClinicId { get; set; }
        public required int Number { get; set; }
    }
}
