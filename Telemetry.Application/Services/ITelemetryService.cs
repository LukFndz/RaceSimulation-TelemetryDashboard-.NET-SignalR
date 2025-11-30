using Telemetry.Application.Dto;

namespace Telemetry.Application.Services;

public interface ITelemetryService
{
    Task ProcessTelemetryAsync(TelemetryDto dto, CancellationToken cancellationToken = default);
}
