// ag=no
namespace LiveRoomApplication.Shared.Automaps; 
public partial class LiveRoomSessionTagMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionTagMap";
    
    public LiveRoomSessionTagMap()
    {
        CreateMap<LiveRoomSessionTag, LiveRoomSessionTagViewModel>()
        .ForMember(d => d.LiveRoomSessions, opt => opt.Ignore())
        ;
        CreateMap<LiveRoomSessionTagViewModel, LiveRoomSessionTag>()
        .ForMember(d => d.LiveRoomSessions, opt => opt.Ignore())
        ;
    }
}