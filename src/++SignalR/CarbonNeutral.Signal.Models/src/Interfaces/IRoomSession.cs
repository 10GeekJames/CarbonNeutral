namespace CarbonNeutral.Signal.Models;
public interface IRoomSession
{
    JArray? Options { get; set; }
    string? CurrentRoomMessage { get; set; }
}