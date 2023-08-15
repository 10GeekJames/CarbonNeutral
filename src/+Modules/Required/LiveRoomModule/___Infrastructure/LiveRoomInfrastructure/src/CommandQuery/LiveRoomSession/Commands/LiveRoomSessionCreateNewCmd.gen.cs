// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionCreateNewCmd : IRequest<LiveRoomSession>
{
    public string Slug { get; set; }
    public string Title { get; set; }
    public Guid? KnownUserId { get; set; } = null;
    public LiveRoomSessionCreateNewCmd() { }
    public LiveRoomSessionCreateNewCmd(string slug, string title, Guid? knownUserId = null)
    {
        Slug = slug;
        Title = title;
        KnownUserId = knownUserId;
    }
}
