// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountGetByEmailRequestMap : Profile
{ 
    public override string ProfileName => "KnownAccountGetByEmailRequestMap";
    
    public KnownAccountGetByEmailRequestMap()
    {
        CreateMap<KnownAccountGetByEmailRequest, KnownAccountGetByEmailQry>()
        .ReverseMap();
    }
}