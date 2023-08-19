namespace CarbonNeutral.Signal.Hubs;
public class CarbonNeutralHub : Hub<ICarbonNeutralHubClient>
{
    public static ConcurrentDictionary<string, Guest> _roomGuests { get; set; } = new();
    public static ConcurrentDictionary<string, RoomSession> _roomSessions = new ConcurrentDictionary<string, RoomSession>();

    public void CreateNewRoomAsync(JObject data)
    {
        var roomKey = (string)data["roomKey"];
        var individual = (JObject)data["individual"];
        if (roomKey != null && roomKey.Length > 0)
        {
            RoomSession roomSession;
            _roomSessions.TryGetValue(roomKey, out roomSession);
            if (roomSession == null)
            {
                roomSession = new RoomSession();
            }

            roomSession.CurrentRoomMessage = "";

            /* using (var dbContext = new CarbonNeutralSignalRDbContext())
            {
                dbContext.Configuration.LazyLoadingEnabled = false;
                dbContext.Configuration.ProxyCreationEnabled = false;
                var room = dbContext.Rooms.FirstOrDefault(rs => rs.RoomKey == roomKey);
                if (room == null)
                {
                    room = new Room() { RoomKey = roomKey, EventStartDate = DateTime.Now.ToUniversalTime()};
                    dbContext.Rooms.Add(room);
                    dbContext.SaveChanges();
                }
                roomSession.CurrentRoomId = room.Id;
            }
            _roomSessions.AddOrUpdate(roomKey, roomSession, (key, sessionData) =>
            {
                sessionData.Options = roomSession.Options;
                sessionData.CurrentRoomMessage = roomSession.CurrentRoomMessage;
                return sessionData;
            }); */
            //Clients.Client(Context.ConnectionId).newRoomReady(roomSession);
            Clients.Group(roomKey).newRoomReadyAsync(roomSession);
        }
    }

    public override Task OnConnectedAsync()
    {
        Console.WriteLine("A new visitor!");
        _roomGuests.TryAdd(Context.ConnectionId, new Guest { ConnectionId = Context.ConnectionId, RoomKey = "-8" });
        // Clients.All.addedGuestFromTheRoomSignalR(Context.ConnectionId);
        var guestCount = _roomGuests.Count();
        Clients.All.addedGuestFromTheRoomSignalRAsync(guestCount);
        return base.OnConnectedAsync();
    }
    public override Task OnDisconnectedAsync(Exception exception)
    {
        var list = new Guest();
        _roomGuests.TryRemove(Context.ConnectionId, out list);

        var guestCount = _roomGuests.Count();
        // Clients.All.removedGuestFromTheRoomSignalR(Context.ConnectionId);
        Clients.All.removedGuestFromTheRoomSignalRAsync(Context.ConnectionId);

        return base.OnDisconnectedAsync(exception);
    }

    public struct Guest
    {
        public string ConnectionId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string RoomKey { get; set; }
        //public DateTime LastSignal { get; set; }
    }
    public async Task SendMessageAsync(string userName, string room, string message)
    {
        await Clients.Group(room).receiveMessageAsync($"{userName} says, {message}");
    }
    public async Task AddToGroupAsync(string group, string user)
    {
        await Groups.AddToGroupAsync(Context.ConnectionId, group);
        System.Console.WriteLine($"Added to group {group}, {user}");
        await Clients.Group(group).receiveMessageAsync($"Added to group {group}, {user}");
    }
    public async void RemovePersonFromRoomAsync(Newtonsoft.Json.Linq.JObject data)
    {
        Guest value;
        dynamic dData = data;
        var roomKey = dData.roomKey;
        _roomGuests.TryRemove(roomKey, out value);
        //await Groups.RemoveAsync(Context.ConnectionId, roomKey);
        //Clients.All.removePersonFromRoom(data);
        Clients.Group(dData.roomKey).guestCountUpdated(_roomGuests.Count(guest => guest.Value.RoomKey.Equals(dData.roomKey)));
    }
    public async Task JoinLiveRoom(string roomName, string userName)
    {
        if (roomName == "")
        {
            Console.WriteLine("Room name is missing");
        }
        await AddToGroupAsync(roomName, userName);
    }
}
