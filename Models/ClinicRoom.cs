namespace ClinicManagementInternship.Models
{
    public class ClinicRoom : ModelBase
    {
        public required int ClinicId { get; set; }
        public Clinic? Clinic { get; set; }
        public required int Number { get; set; }
    }
}
