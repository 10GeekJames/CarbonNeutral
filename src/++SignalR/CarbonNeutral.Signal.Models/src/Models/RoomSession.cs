namespace CarbonNeutral.Signal.Models;
public class RoomSession : IRoomSession
{
    public JArray? Options { get; set; }
    public string? CurrentRoomMessage { get; set; }
}
