namespace CarbonNeutral.Common.Interfaces;
public interface ISignalRService
{
    event Action OnChange;

    bool IsConnected { get; }
    bool IsConnecting { get; }
    string UserName { get; }

    HubConnection HubConnection { get; }

    Task sendMessageAsync(string user, string message);
    Task addToGroupAsync(string group);
    Task removeFromGroupAsync(string group);
    Task newRoomReadyAsync(RoomSession roomSession);
    Task addedGuestFromTheRoomSignalRAsync(int guestCount);
    Task removedGuestFromTheRoomSignalRAsync(string connectionId);
    Task newRoomMessageAsync(string message);
    Task newRoomMessageFromServerAsync(string message);
    Task receiveMessageAsync(string message);
    void SetUserName(string userName);
}