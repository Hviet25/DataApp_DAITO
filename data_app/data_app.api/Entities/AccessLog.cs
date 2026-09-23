using System.Net;

namespace data_app.api.Entities
{
    public class AccessLog
    {
        public long LogId { get; set; }
        public Guid? UserId { get; set; }
        public string ActionType { get; set; } = string.Empty;
        public bool Success { get; set; }
        public IPAddress? IpAddress { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
    }
}
