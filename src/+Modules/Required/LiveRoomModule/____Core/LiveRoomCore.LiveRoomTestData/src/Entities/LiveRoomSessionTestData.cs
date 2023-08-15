namespace LiveRoomCore.LiveRoomTestData.Entities;
public static class LiveRoomSessionTestData
{
    public static LiveRoomSession NormalEasyLiveRoomSession;       
    public static Guid NormalEasyLiveRoomSessionId = new Guid("1bd736d2-da2d-48c0-b19f-a0ec98396d49");

    public static IEnumerable<LiveRoomSession> AllLiveRoomSessions;

    static LiveRoomSessionTestData()
    {
        var roomSlug = "room-a";
        var title = "My first awesome liveRoomSession!";
        
        NormalEasyLiveRoomSession = new (NormalEasyLiveRoomSessionId, roomSlug, title);

        AllLiveRoomSessions = new List<LiveRoomSession> {
            NormalEasyLiveRoomSession
        };
    }
}
