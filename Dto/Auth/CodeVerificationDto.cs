namespace ClinicManagementInternship.Dto.Auth
{
    public class CodeVerificationDto
    {
        public required string Email { get; set; }
        public required string Code { get; set; }
    }
}
