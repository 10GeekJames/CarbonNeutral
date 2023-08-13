namespace LiveRoomCore.LiveRoomTestData.Entities;
public static class LiveRoomSessionTestData
{
    public static LiveRoomSession NormalEasyLiveRoomSession;       
    public static Guid NormalEasyLiveRoomSessionId = new Guid("1bd736d2-da2d-48c0-b19f-a0ec98396d49");

    public static IEnumerable<LiveRoomSession> AllLiveRoomSessions;

    static LiveRoomSessionTestData()
    {
        var title = "My first awesome liveRoomSession!";
        var height = 25;
        var width = 25;
        var wordsToHide = new List<HiddenWord> { new("Sally"), new("Billy"), new("Larry"), new("Franky"), new("George") }.AsReadOnly();
        var liveRoomSessionDifficulty = LiveRoomSessionDifficulties.Easy;
        var liveRoomSessionCategories = new List<LiveRoomSessionCategory> { new("Shared"), new("Home"), new("School") }.AsReadOnly();
        var liveRoomSessionTags = new List<LiveRoomSessionTag> { new("Fiction"), new("Adventure"), new("Action") }.AsReadOnly();
        
        NormalEasyLiveRoomSession = new (NormalEasyLiveRoomSessionId, title, height, width, wordsToHide, liveRoomSessionDifficulty, liveRoomSessionCategories, liveRoomSessionTags);

        AllLiveRoomSessions = new List<LiveRoomSession> {
            NormalEasyLiveRoomSession
        };
    }
}
