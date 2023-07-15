// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessMap : Profile
{ 
    public override string ProfileName => "KnownBusinessMap";
    
    public KnownBusinessMap()
    {
        CreateMap<KnownBusiness, KnownBusinessViewModel>()
        .ReverseMap();
    }
}