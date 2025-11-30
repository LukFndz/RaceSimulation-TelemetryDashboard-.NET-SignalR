namespace Telemetry.Domain.Entities;

public class TelemetrySample
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime Timestamp { get; set; }

    public float SpeedKmh { get; set; }
    public int Rpm { get; set; }
    public int Gear { get; set; }

    public float Throttle { get; set; }
    public float Brake { get; set; }

    public float TireTempFL { get; set; }
    public float TireTempFR { get; set; }
    public float TireTempRL { get; set; }
    public float TireTempRR { get; set; }

    public float FuelRemainingKg { get; set; }
    public bool DrsActive { get; set; }
}
