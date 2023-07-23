// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountGetByNameRequestMap : Profile
{ 
    public override string ProfileName => "KnownAccountGetByNameRequestMap";
    
    public KnownAccountGetByNameRequestMap()
    {
        CreateMap<KnownAccountGetByNameRequest, KnownAccountGetByNameQry>()
        .ReverseMap();
    }
}