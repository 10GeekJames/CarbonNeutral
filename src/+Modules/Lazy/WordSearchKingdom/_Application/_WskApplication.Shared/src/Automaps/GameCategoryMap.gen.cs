// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class GameCategoryMap : Profile
{ 
    public override string ProfileName => "GameCategoryMap";
    
    public GameCategoryMap()
    {
        CreateMap<GameCategory, GameCategoryViewModel>()
        .ReverseMap();
    }
}