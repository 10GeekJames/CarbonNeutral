// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessProfileMap : Profile
{ 
    public override string ProfileName => "KnownBusinessProfileMap";
    
    public KnownBusinessProfileMap()
    {
        CreateMap<KnownBusinessProfile, KnownBusinessProfileViewModel>()
        .ReverseMap();
    }
}