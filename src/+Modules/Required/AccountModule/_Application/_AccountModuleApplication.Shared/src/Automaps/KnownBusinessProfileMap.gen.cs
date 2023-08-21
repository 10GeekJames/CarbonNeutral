// ag=no
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownBusinessProfileMap : Profile
{ 
    public override string ProfileName => "KnownBusinessProfileMap";
    
    public KnownBusinessProfileMap()
    {
        CreateMap<KnownBusinessProfile, KnownBusinessProfileViewModel>()
        .ForMember(rs=>rs.KnownBusiness, rs=>rs.Ignore())   
        .ReverseMap();
    }
}