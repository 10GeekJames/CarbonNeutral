// ag=no
namespace WskApplication.Shared.Automaps; 
public partial class GameCategoryMap : Profile
{ 
    public override string ProfileName => "GameCategoryMap";
    
    public GameCategoryMap()
    {
        CreateMap<GameCategory, GameCategoryViewModel>()
        .ForMember(d => d.Games, opt => opt.Ignore());

        CreateMap<GameCategoryViewModel, GameCategory>()
        .ForMember(d => d.Games, opt => opt.Ignore());        
    }
}