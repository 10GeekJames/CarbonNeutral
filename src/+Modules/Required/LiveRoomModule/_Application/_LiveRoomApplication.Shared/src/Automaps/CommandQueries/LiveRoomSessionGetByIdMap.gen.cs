// ag=yes
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionGetByIdRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionGetByIdRequestMap";
    
    public LiveRoomSessionGetByIdRequestMap()
    {
        CreateMap<LiveRoomSessionGetByIdRequest, LiveRoomSessionGetByIdQry>()
        .ReverseMap();
    }
}