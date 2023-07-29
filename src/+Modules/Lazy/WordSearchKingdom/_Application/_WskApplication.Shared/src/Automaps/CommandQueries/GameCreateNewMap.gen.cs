// ag=no
namespace WskApplication.Automaps; 
public partial class GameCreateNewRequestMap : Profile
{ 
    public override string ProfileName => "GameCreateNewRequestMap";
    
    public GameCreateNewRequestMap()
    {
        CreateMap<GameCreateNewRequest, GameCreateNewCmd>()
        .ForMember(d => d.GameTags, opt => opt.Ignore());

        CreateMap<GameCreateNewCmd, GameCreateNewRequest>()
        .ForMember(d => d.GameTags, opt => opt.Ignore());
    }
}