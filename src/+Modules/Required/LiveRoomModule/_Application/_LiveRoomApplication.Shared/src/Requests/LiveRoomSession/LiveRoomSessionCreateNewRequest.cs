namespace LiveRoomApplication.Shared.Requests;

public class LiveRoomSessionCreateNewRequest : IRoutable
{
    protected readonly static string Route = "liveRoomSession/createnew";
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public List<HiddenWordViewModel> WordsToHide { get; set; }
    public LiveRoomSessionDifficulties LiveRoomSessionDifficulty { get; set; }
    public List<LiveRoomSessionCategoryViewModel> LiveRoomSessionCategories { get; set; }
    public List<LiveRoomSessionTagViewModel> LiveRoomSessionTags { get; set; }
    public Guid? KnownUserId { get; set; } = null;

    public LiveRoomSessionCreateNewRequest() { }
    public LiveRoomSessionCreateNewRequest(string title, int height, int width, List<HiddenWordViewModel> wordsToHide, LiveRoomSessionDifficulties liveRoomSessionDifficulty, List<LiveRoomSessionCategoryViewModel> liveRoomSessionCategories, List<LiveRoomSessionTagViewModel> liveRoomSessionTags)
    {
        Title = title;
        Height = height;
        Width = width;
        WordsToHide = wordsToHide;
        LiveRoomSessionDifficulty = liveRoomSessionDifficulty;
        LiveRoomSessionCategories = liveRoomSessionCategories;
        LiveRoomSessionTags = liveRoomSessionTags;
    }
    public string BuildRouteFrom() => LiveRoomSessionCreateNewRequest.BuildRoute();
    public static string BuildRoute() => Route;
}
