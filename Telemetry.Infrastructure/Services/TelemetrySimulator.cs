using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;
using Telemetry.Application.Services;
using Telemetry.Application.Dto;

namespace Telemetry.Infrastructure.Services
{
    public class TelemetrySimulator : BackgroundService
    {
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly Random _rnd = new();

        public TelemetrySimulator(IServiceScopeFactory scopeFactory)
        {
            _scopeFactory = scopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using var scope = _scopeFactory.CreateScope();
                var telemetryService = scope.ServiceProvider.GetRequiredService<ITelemetryService>();

                var dto = GenerateFakeTelemetry();

                await telemetryService.ProcessTelemetryAsync(dto, stoppingToken);

                await Task.Delay(500, stoppingToken);
            }
        }

        private TelemetryDto GenerateFakeTelemetry()
        {
            return new TelemetryDto(
                Timestamp: DateTime.UtcNow,
                SpeedKmh: _rnd.Next(0, 330),
                Rpm: _rnd.Next(3000, 15000),
                Gear: _rnd.Next(1, 8),
                Throttle: (float)_rnd.NextDouble(),
                Brake: (float)_rnd.NextDouble(),
                TireTempFL: _rnd.Next(70, 130),
                TireTempFR: _rnd.Next(70, 130),
                TireTempRL: _rnd.Next(70, 130),
                TireTempRR: _rnd.Next(70, 130),
                FuelRemainingKg: (float)_rnd.NextDouble() * 110,
                DrsActive: _rnd.NextDouble() > 0.7
            );
        }
    }
}
