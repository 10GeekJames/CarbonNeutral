// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessAddChildBusinessRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessAddChildBusinessRequestMap";
    
    public KnownBusinessAddChildBusinessRequestMap()
    {
        CreateMap<KnownBusinessAddChildBusinessRequest, KnownBusinessAddChildBusinessCmd>()
        .ReverseMap();
    }
}