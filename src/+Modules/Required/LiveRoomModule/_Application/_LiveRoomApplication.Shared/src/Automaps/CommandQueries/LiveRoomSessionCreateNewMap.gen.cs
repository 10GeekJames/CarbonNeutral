// ag=no
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionCreateNewRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionCreateNewRequestMap";
    
    public LiveRoomSessionCreateNewRequestMap()
    {
        CreateMap<LiveRoomSessionCreateNewRequest, LiveRoomSessionCreateNewCmd>()
        .ForMember(d => d.LiveRoomSessionTags, opt => opt.Ignore());

        CreateMap<LiveRoomSessionCreateNewCmd, LiveRoomSessionCreateNewRequest>()
        .ForMember(d => d.LiveRoomSessionTags, opt => opt.Ignore());
    }
}