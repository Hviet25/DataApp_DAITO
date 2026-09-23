namespace data_app.api.Models
{
    public class VerifyOtpRequest
    {
        public Guid UserId { get; set; }
        public long OtpId { get; set; }
        public string OtpCode { get; set; } = string.Empty;
    }
}
