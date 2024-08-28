using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Injection
{
    public class CreateInjection : GenericDTO
    {
        public required int PatientId { get; set; }
        public required int DoctorId { get; set; }
        public required int DrugId { get; set; }
    }
}
