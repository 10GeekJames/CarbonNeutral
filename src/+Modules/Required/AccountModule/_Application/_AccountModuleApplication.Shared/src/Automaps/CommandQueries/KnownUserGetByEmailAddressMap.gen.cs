// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownUserGetByEmailAddressRequestMap : Profile
{ 
    public override string ProfileName => "KnownUserGetByEmailAddressRequestMap";
    
    public KnownUserGetByEmailAddressRequestMap()
    {
        CreateMap<KnownUserGetByEmailAddressRequest, KnownUserGetByEmailAddressQry>()
        .ReverseMap();
    }
}