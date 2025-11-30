using Microsoft.AspNetCore.Mvc;
using Telemetry.Application.Dto;
using Telemetry.Application.Services;

namespace Telemetry.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TelemetryController : ControllerBase
{
    private readonly ITelemetryService _telemetryService;

    public TelemetryController(ITelemetryService telemetryService)
    {
        _telemetryService = telemetryService;
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] TelemetryDto dto, CancellationToken cancellationToken)
    {
        await _telemetryService.ProcessTelemetryAsync(dto, cancellationToken);
        return Ok();
    }
}
