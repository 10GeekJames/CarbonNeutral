// ag=no *******
namespace LiveRoomApplication.Automaps; 
public partial class LiveRoomSessionCheckWordCoordsRequestMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionCheckWordCoordsRequestMap";
    
    public LiveRoomSessionCheckWordCoordsRequestMap()
    {
        CreateMap<LiveRoomSessionCheckWordCoordsRequest, LiveRoomSessionCheckWordCoordsQry>()
        .ReverseMap();
    }
}