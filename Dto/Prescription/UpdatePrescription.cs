using ClinicManagementInternship.Templates;

namespace ClinicManagementInternship.Dto.Prescription
{
    public class UpdatePrescription : GenericUpdateDTO
    {
        public int? DurationDays { get; set; }
        public string? Notes { get; set; }
    }
}
