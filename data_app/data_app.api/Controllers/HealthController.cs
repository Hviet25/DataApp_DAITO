using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using data_app.api.Data;

namespace data_app.api.Controllers;

[ApiController]
[Route("api/health")]
public class HealthController: ControllerBase
{
    private readonly AppDbContext _db;

    public HealthController(AppDbContext db)
    {
        _db = db;
    }
    [HttpGet("db")]
    public async Task<IActionResult> CheckDatabse(CancellationToken cancellationToken)
    {
        var connected = await _db.Database.CanConnectAsync(cancellationToken);
        if (!connected)
        {
            return StatusCode(503, new { connected = false, message = "Cannot connect to Lakebase" });
        }

        return Ok(new { connected = true, database = "Lakebase" });
    }
}

