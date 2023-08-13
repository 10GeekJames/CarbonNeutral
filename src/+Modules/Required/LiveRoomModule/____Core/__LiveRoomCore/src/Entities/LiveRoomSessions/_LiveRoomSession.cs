namespace LiveRoomCore.Entities;

public class LiveRoomSession : BaseEntityTracked<Guid>, IAggregateRoot
{
    public string Title { get; private set; }
    public Guid? KnownUserId { get; private set; } = null;
    public LiveRoomSessionDifficulties LiveRoomSessionDifficulty { get; private set; }
    private List<LiveRoomSessionCategory> _liveRoomSessionCategories = new();
    public IEnumerable<LiveRoomSessionCategory> LiveRoomSessionCategories => _liveRoomSessionCategories.AsReadOnly();
    private List<LiveRoomSessionTag> _liveRoomSessionTags = new();
    public IEnumerable<LiveRoomSessionTag> LiveRoomSessionTags => _liveRoomSessionTags.AsReadOnly();
    public LiveRoomSessionGrid LiveRoomSessionGrid { get; private set; }

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    private LiveRoomSession() { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public LiveRoomSession(Guid id, string title, int height, int width, IEnumerable<HiddenWord> hiddenWords, LiveRoomSessionDifficulties liveRoomSessionDifficulty, IEnumerable<LiveRoomSessionCategory> liveRoomSessionCategories, IEnumerable<LiveRoomSessionTag> liveRoomSessionTags, Guid? knownUserId = null) : this(title, height, width, hiddenWords, liveRoomSessionDifficulty, liveRoomSessionCategories, liveRoomSessionTags, knownUserId)
    {
        Id = id;
    }

    public LiveRoomSession(string title, int height, int width, IEnumerable<HiddenWord> hiddenWords, LiveRoomSessionDifficulties liveRoomSessionDifficulty, IEnumerable<LiveRoomSessionCategory> liveRoomSessionCategories, IEnumerable<LiveRoomSessionTag> liveRoomSessionTags, Guid? knownUserId = null)
    {
        LiveRoomSessionGrid = new LiveRoomSessionGrid(height, width, hiddenWords);

        LiveRoomSessionDifficulty = liveRoomSessionDifficulty;
        _liveRoomSessionCategories = liveRoomSessionCategories.ToList();
        _liveRoomSessionTags = liveRoomSessionTags.ToList();

        Title = title;

        KnownUserId = knownUserId;
    }

    public void RecreateGrid()
    {
        LiveRoomSessionGrid.RecreateGrid();
    }
}
