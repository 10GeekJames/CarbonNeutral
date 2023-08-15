namespace LiveRoomCore.Entities;

public class LiveRoomSession : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    /* [Index("IX_LiveRoomSession_RoomName", IsUnique = true)]         */
    public string Slug { get; private set; }
    public Guid? KnownUserId { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private LiveRoomSession() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LiveRoomSession(Guid id, string slug, string title, Guid? knownUserId = null) : this(slug, title, knownUserId)
    {
        Id = id;
    }

    public LiveRoomSession(string slug, string title, Guid? knownUserId = null)
    {
        Slug = slug;
        Title = title;
        KnownUserId = knownUserId;
    }
}
