namespace CarbonNeutral.Service.SignalR.Hubs;
public class CarbonNeutralHub : Hub
{
    public async Task SendMessage(string user, string message)
    {
        await Clients.All.SendAsync("ReceiveMessage", user, message);
    }
}
