// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionCreateNewCmd : IRequest<LiveRoomSession>
{
    public string Title { get; set; }
    public int Height { get; set; }
    public int Width { get; set; }
    public List<HiddenWord> WordsToHide { get; set; }
    public LiveRoomSessionDifficulties LiveRoomSessionDifficulty { get; set; }
    public List<LiveRoomSessionCategory> LiveRoomSessionCategories { get; set; }
    public List<LiveRoomSessionTag> LiveRoomSessionTags { get; set; }
    public Guid? KnownUserId { get; set; } = null;
    public LiveRoomSessionCreateNewCmd() { }
    public LiveRoomSessionCreateNewCmd(string title, int height, int width, List<HiddenWord> wordsToHide, LiveRoomSessionDifficulties liveRoomSessionDifficulty, List<LiveRoomSessionCategory> liveRoomSessionCategories, List<LiveRoomSessionTag> liveRoomSessionTags)
    {
        Title = title;
        Height = height;
        Width = width;
        WordsToHide = wordsToHide;
        LiveRoomSessionDifficulty = liveRoomSessionDifficulty;
        LiveRoomSessionCategories = liveRoomSessionCategories;
        LiveRoomSessionTags = liveRoomSessionTags;
    }
}
