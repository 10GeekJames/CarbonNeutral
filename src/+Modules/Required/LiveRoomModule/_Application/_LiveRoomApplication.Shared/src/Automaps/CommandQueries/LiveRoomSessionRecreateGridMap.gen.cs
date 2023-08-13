// ag=yes
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionRecreateGridRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionRecreateGridRequestMap";
    
    public LiveRoomSessionRecreateGridRequestMap()
    {
        CreateMap<LiveRoomSessionRecreateGridRequest, LiveRoomSessionRecreateGridCmd>()
        .ReverseMap();
    }
}