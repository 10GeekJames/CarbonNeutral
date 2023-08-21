// ag=yes
namespace AccountModuleApplication.Shared.Automaps; 
public partial class KnownAccountSubscriptionMap : Profile
{ 
    public override string ProfileName => "KnownAccountSubscriptionMap";
    
    public KnownAccountSubscriptionMap()
    {
        CreateMap<KnownAccountSubscription, KnownAccountSubscriptionViewModel>()
        .ReverseMap();
    }
}