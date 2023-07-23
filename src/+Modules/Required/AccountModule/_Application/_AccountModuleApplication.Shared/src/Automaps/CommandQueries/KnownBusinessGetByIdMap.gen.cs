// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownBusinessGetByIdRequestMap : Profile
{ 
    public override string ProfileName => "KnownBusinessGetByIdRequestMap";
    
    public KnownBusinessGetByIdRequestMap()
    {
        CreateMap<KnownBusinessGetByIdRequest, KnownBusinessGetByIdQry>()
        .ReverseMap();
    }
}