// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessGetChildBusinessesRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessGetChildBusinessesRequestMap";
    
    public KnownBusinessGetChildBusinessesRequestMap()
    {
        CreateMap<KnownBusinessGetChildBusinessesRequest, KnownBusinessGetChildBusinessesQry>()
        .ReverseMap();
    }
}