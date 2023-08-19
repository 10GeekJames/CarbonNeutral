// ag=yes
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionCreateNewRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionCreateNewRequestMap";
    
    public LiveRoomSessionCreateNewRequestMap()
    {
        CreateMap<LiveRoomSessionCreateNewRequest, LiveRoomSessionCreateNewCmd>()
        .ReverseMap();
    }
}