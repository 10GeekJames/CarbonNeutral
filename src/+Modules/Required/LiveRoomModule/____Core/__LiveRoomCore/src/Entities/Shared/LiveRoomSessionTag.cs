namespace LiveRoomCore.Entities;
public class LiveRoomSessionTag : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    private List<LiveRoomSession> _liveRoomSessions = new();
    public IEnumerable<LiveRoomSession> LiveRoomSessions => _liveRoomSessions.AsReadOnly();
    
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private LiveRoomSessionTag(){}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public LiveRoomSessionTag(string title)
    {
        Title = title;
    }
}
