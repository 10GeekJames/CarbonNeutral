// ag=no
namespace WskApplication.Shared.Automaps; 
public partial class GameTagMap : Profile
{ 
    public override string ProfileName => "GameTagMap";
    
    public GameTagMap()
    {
        CreateMap<GameTag, GameTagViewModel>()
        .ForMember(d => d.Games, opt => opt.Ignore())
        ;
        CreateMap<GameTagViewModel, GameTag>()
        .ForMember(d => d.Games, opt => opt.Ignore())
        ;
    }
}