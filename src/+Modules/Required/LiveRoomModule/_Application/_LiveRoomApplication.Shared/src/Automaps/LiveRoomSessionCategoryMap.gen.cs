// ag=no
namespace LiveRoomApplication.Shared.Automaps; 
public partial class LiveRoomSessionCategoryMap : Profile
{ 
    public override string ProfileName => "LiveRoomSessionCategoryMap";
    
    public LiveRoomSessionCategoryMap()
    {
        CreateMap<LiveRoomSessionCategory, LiveRoomSessionCategoryViewModel>()
        .ForMember(d => d.LiveRoomSessions, opt => opt.Ignore());

        CreateMap<LiveRoomSessionCategoryViewModel, LiveRoomSessionCategory>()
        .ForMember(d => d.LiveRoomSessions, opt => opt.Ignore());        
    }
}