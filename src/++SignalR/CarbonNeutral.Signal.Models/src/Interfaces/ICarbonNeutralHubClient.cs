namespace CarbonNeutral.Signal.Models;
public interface ICarbonNeutralHubClient
{
    Task sendMessageAsync(string user, string roomName, string message);
    Task addToGroupAsync(string group);
    Task removeFromGroupAsync(string group);    
    Task newRoomReadyAsync(RoomSession roomSession);
    Task addedGuestFromTheRoomSignalRAsync(int guestCount);
    Task removedGuestFromTheRoomSignalRAsync(string connectionId);
    Task newRoomMessageAsync(string message);
    Task newRoomMessageFromServerAsync(string message);
    Task receiveMessageAsync(string message);
    Task joinLiveRoom(string roomName);
}
