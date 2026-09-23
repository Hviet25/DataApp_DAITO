using System.Security;

namespace data_app.api.Models
{
    public class LoginResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; } = string.Empty;
        public bool RequiresOtp { get; set; }
        public Guid? UserId { get; set; }
        public long? OtpId { get; set; }
        public DateTimeOffset? OtpExpiresAt { get; set; }
    }
}
