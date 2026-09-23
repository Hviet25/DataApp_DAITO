using System.Net;
using data_app.api.Data;
using data_app.api.Entities;

namespace data_app.api.Services;
public class LogService
{
   private readonly AppDbContext _db;
   public LogService(AppDbContext db)
   {
        _db = db;
   }
   public async Task WriteAsync(
        Guid? userId,
        string actionType,
        bool success,
        IPAddress? iPAddress)
   {
        _db.AccessLogs.Add(new AccessLog
        {
            UserId = userId,
            ActionType = actionType,
            Success = success,
            IpAddress = iPAddress,
            CreatedAt = DateTimeOffset.UtcNow
        });
        await _db.SaveChangesAsync();
   }
}
