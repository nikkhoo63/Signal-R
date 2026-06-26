using Microsoft.AspNetCore.SignalR;

namespace SignalR_Lab.Hubs
{
    public class TimeHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
    
            await base.OnConnectedAsync();
        }
    
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            Console.WriteLine($"Client disconnected: {Context.ConnectionId}");
    
            await base.OnDisconnectedAsync(exception);
        }
    
        public async Task RequestServerTime()
        {
            await Clients.Caller.SendAsync(
                "ReceiveTime",
                DateTime.UtcNow.ToString("O")
            );
        }
    }
}

