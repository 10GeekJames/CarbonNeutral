// ag=yes
namespace LiveRoomApplication.Shared.Automaps; 
public partial class LiveRoomSessionMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionMap";
    
    public LiveRoomSessionMap()
    {
        CreateMap<LiveRoomSession, LiveRoomSessionViewModel>()
        .ReverseMap();
    }
}