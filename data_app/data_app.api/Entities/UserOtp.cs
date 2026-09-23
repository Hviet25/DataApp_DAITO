namespace data_app.api.Entities
{
    public class UserOtp
    {
        public long OtpId { get; set; }
        public Guid UserId { get; set; }
        public string OtpHash { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset ExpiresAt { get; set; }
        public bool IsUsed { get; set; }
        public int Attempts { get; set; }
        public DateTimeOffset? UsedAt { get; set; }
    }
}
