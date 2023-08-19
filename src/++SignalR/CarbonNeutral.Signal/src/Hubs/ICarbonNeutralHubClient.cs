namespace CarbonNeutral.Signal.Hubs;
public interface ICarbonNeutralHubClient
{
    Task sendMessage(string user, string message);
    Task addToGroupAsync(string group);
    Task removeFromGroupAsync(string group);    
    Task newRoomReady(RoomSession roomSession);
    Task addedGuestFromTheRoomSignalR(int guestCount);
    Task removedGuestFromTheRoomSignalR(string connectionId);
    Task newRoomMessage(string message);
    Task newRoomMessageFromServer(string message);
    Task receiveMessageAsync(string message);
}
