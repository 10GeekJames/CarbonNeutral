// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownUserProfileViewModel : BaseViewModel<Guid>
{ 

     [MaxLength(101)]
     public string Name { get; set; } = String.Empty;
     public Guid KnownUserId { get; set; } = Guid.Empty;
     public KnownUserViewModel KnownUser { get; set; }
     public Guid KnownBusinessWebsiteId { get; set; } = Guid.Empty;
     public KnownBusinessWebsiteViewModel KnownBusinessWebsite { get; set; }

} 
        