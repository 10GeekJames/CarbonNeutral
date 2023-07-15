// ag=yes
namespace AccountModuleApplication.Automaps; 
public partial class KnownAccountSubscriptionMap : Profile
{ 
    public override string ProfileName => "KnownAccountSubscriptionMap";
    
    public KnownAccountSubscriptionMap()
    {
        CreateMap<KnownAccountSubscription, KnownAccountSubscriptionViewModel>()
        .ReverseMap();
    }
}