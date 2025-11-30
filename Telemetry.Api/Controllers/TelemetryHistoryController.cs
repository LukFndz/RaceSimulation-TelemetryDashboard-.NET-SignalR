using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Telemetry.Infrastructure.Data;

namespace Telemetry.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelemetryHistoryController : ControllerBase
{
    private readonly TelemetryDbContext _db;

    public TelemetryHistoryController(TelemetryDbContext db)
    {
        _db = db;
    }

    // Get last N Telemetry RPM History by count
    [HttpGet("latest/{count}")]
    public async Task<IActionResult> GetLatest(int count = 50)
    {
        var data = await _db.TelemetrySamples
            .OrderByDescending(t => t.Timestamp)
            .Take(count)
            .ToListAsync();

        return Ok(data);
    }

    // Get last n by Telemetry RPM History by Time Range
    [HttpGet("range")]
    public async Task<IActionResult> GetRange(DateTime from, DateTime to)
    {
        var data = await _db.TelemetrySamples
            .Where(t => t.Timestamp >= from && t.Timestamp <= to)
            .OrderBy(t => t.Timestamp)
            .ToListAsync();

        return Ok(data);
    }
}
