
using System;
namespace CarbonNeutral.Common.Services;
public class SignalRService : ISignalRService
{
    public HubConnection HubConnection { get; private set; }

    public string UserName { get; private set; } = "";
    private void NotifyStateChanged() => OnChange?.Invoke();
    public event Action OnChange;
    public bool IsConnected =>
        HubConnection.State == HubConnectionState.Connected;
    public bool IsConnecting { get; private set; } = false;
    private List<string> joinedUsers = new List<string>();

    public SignalRService()
    {
        UserName = "user" + new Random().Next(1, 982734892);
        Startup();
    }
    public void SetUserName(string userName)
    {
        this.UserName = userName;
        this.NotifyStateChanged();
    }
    private async Task Startup()
    {
        HubConnection = await GetActiveConnection();
    }
    public async Task joinLiveRoom(string roomName)
    {
        GetActiveConnection();
        if (roomName == "")
        {
            Console.WriteLine("Room name is missing");
        }
        var userKey = roomName + "|" + UserName;
        /* if (!this.joinedUsers.Contains(userKey))
        { */
        this.joinedUsers.Add(userKey);

        await HubConnection.SendAsync("JoinLiveRoom", roomName, UserName);
        /* }
        else
        {
            Console.WriteLine("User has already joined room");
        } */
    }
    public async Task addToGroupAsync(string roomName)
    {
        if (roomName == "")
        {
            Console.WriteLine("Room name is missing");
        }
        var userKey = roomName + "|" + UserName;
        /* if (!this.joinedUsers.Contains(userKey))
        { */
        this.joinedUsers.Add(userKey);

        await HubConnection.SendAsync("addToGroupAsync", roomName, UserName);
        /* }
        else
        {
            Console.WriteLine("User has already joined room");
        } */
    }

    /* public async Task<IDisposable> WatchMessages(Action<string, string, string> func) {
        return HubConnection.On<string, string, string>("ReceiveMessageAsync", (room, userName, message) => {func(room, userName, message);});
    } */

    public async Task sendMessageAsync(string roomName, string message)
    {
        GetActiveConnection();
        await HubConnection.SendAsync("sendMessageAsync", UserName, roomName, message);
    }
    public async Task removeFromGroupAsync(string group)
    {
        throw new NotImplementedException();
    }
    public async Task newRoomReadyAsync(RoomSession roomSession)
    {
        throw new NotImplementedException();
    }
    public async Task addedGuestFromTheRoomSignalRAsync(int guestCount)
    {
        throw new NotImplementedException();
    }
    public async Task removedGuestFromTheRoomSignalRAsync(string connectionId)
    {
        throw new NotImplementedException();
    }
    public async Task newRoomMessageAsync(string message)
    {
        throw new NotImplementedException();
    }
    public async Task newRoomMessageFromServerAsync(string message)
    {
        throw new NotImplementedException();
    }
    public async Task receiveMessageAsync(string message)
    {
        throw new NotImplementedException();
    }

    private async Task<HubConnection> GetActiveConnection()
    {
        if (HubConnection == null)
        {
            HubConnection =
                new HubConnectionBuilder()
                    .WithUrl("https://signal.wordsearchkingdom.com/carbonneutralhub")
                    //.WithUrl("https://localhost:5021/linuxcmdhub")
                    .WithAutomaticReconnect()
                    .Build();
            await HubConnection.StartAsync();
        }

        return HubConnection;
    }


}
