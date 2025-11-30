namespace Telemetry.Application.Dto;

public record TelemetryDto(
    DateTime Timestamp,
    float SpeedKmh,
    int Rpm,
    int Gear,
    float Throttle,
    float Brake,
    float TireTempFL,
    float TireTempFR,
    float TireTempRL,
    float TireTempRR,
    float FuelRemainingKg,
    bool DrsActive
);
