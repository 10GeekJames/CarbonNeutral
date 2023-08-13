namespace CarbonNeutral.SignalR.Models;
public interface IRoomSession
{
    JArray? Options { get; set; }
    string? CurrentRoomMessage { get; set; }
}