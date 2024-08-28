using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Injection
{
    public class UpdateInjection : GenericUpdateDTO
    {
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public int? DrugId { get; set; }
    }
}
