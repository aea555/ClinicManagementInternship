namespace ClinicManagementInternship.Models
{
    public class SignupConfirmation : ModelBase
    {
        public required string Email { get; set; }
        public required string Code { get; set; }
    }
}
