// ag=yes
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionsGetAllRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionsGetAllRequestMap";
    
    public LiveRoomSessionsGetAllRequestMap()
    {
        CreateMap<LiveRoomSessionsGetAllRequest, LiveRoomSessionsGetAllQry>()
        .ReverseMap();
    }
}