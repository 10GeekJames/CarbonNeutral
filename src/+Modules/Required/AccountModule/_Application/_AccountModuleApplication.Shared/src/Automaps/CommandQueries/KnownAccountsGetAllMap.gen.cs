// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountsGetAllRequestMap : Profile
{ 
    public override string ProfileName => "KnownAccountsGetAllRequestMap";
    
    public KnownAccountsGetAllRequestMap()
    {
        CreateMap<KnownAccountsGetAllRequest, KnownAccountsGetAllQry>()
        .ReverseMap();
    }
}