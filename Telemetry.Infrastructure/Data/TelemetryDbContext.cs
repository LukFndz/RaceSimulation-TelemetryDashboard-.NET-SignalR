using Microsoft.EntityFrameworkCore;
using Telemetry.Domain.Entities;

namespace Telemetry.Infrastructure.Data;

public class TelemetryDbContext : DbContext
{
    public TelemetryDbContext(DbContextOptions<TelemetryDbContext> options) : base(options) { }

    public DbSet<TelemetrySample> TelemetrySamples => Set<TelemetrySample>();
}
