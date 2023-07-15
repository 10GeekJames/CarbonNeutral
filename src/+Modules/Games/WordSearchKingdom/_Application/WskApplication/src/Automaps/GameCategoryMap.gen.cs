// ag=yes
namespace WskApplication.Automaps; 
public partial class GameCategoryMap : Profile
{ 
    public override string ProfileName => "GameCategoryMap";
    
    public GameCategoryMap()
    {
        CreateMap<GameCategory, GameCategoryViewModel>()
        .ReverseMap();
    }
}