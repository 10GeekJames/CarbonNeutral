// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownBusinessViewModel : BaseViewModel<Guid>
{ 

     [MaxLength(101)]
     public string Name { get; set; } = "";
     [MaxLength(200)]
     public string Industry { get; set; } = "";
     public ValidStateCodes? StateCode { get; set; } = null;
     public bool IsActive { get; set; } = true;
     public Guid? ParentBusinessId { get; set; } = null;
     public KnownBusinessViewModel? ParentBusiness { get; set; } = null;
     public List<KnownBusinessProfileViewModel> KnownBusinessProfiles { get; set; } = new();
     public List<KnownBusinessWebsiteViewModel> KnownBusinessWebsites { get; set; } = new();
     public List<KnownBusinessViewModel> ChildBusinesses { get; set; } = new();

} 
        