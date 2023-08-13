// ag=yes
namespace LiveRoomApplication.Shared.Automaps; 
public partial class LiveRoomSessionGridMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionGridMap";
    
    public LiveRoomSessionGridMap()
    {
        CreateMap<LiveRoomSessionGrid, LiveRoomSessionGridViewModel>()
        .ReverseMap();
    }
}