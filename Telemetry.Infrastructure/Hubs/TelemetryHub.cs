using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Telemetry.Infrastructure.Hubs
{
    public class TelemetryHub : Hub
    {
        public async Task SendTelemetry(object telemetry)
        {
            await Clients.All.SendAsync("ReceiveTelemetry", telemetry);
        }
    }
}
