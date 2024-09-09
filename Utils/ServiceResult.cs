namespace ClinicManagementInternship.Utils
{
    public class ServiceResult<T>
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T? Data { get; set; }
        public object? ExtraData { get; set; }
    }
}
