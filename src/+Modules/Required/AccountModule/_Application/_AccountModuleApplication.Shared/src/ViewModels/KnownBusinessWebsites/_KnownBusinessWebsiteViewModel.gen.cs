// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownBusinessWebsiteViewModel : BaseViewModel<Guid>
{ 

     [MaxLength(1024)]
     public string Url { get; set; } = "";
     [MaxLength(101)]
     public string Name { get; set; } = "";
     public bool IsActive { get; set; } = true;
     public KnownBusinessViewModel KnownBusiness { get; set; }
     public KnownBusinessWebsiteProfileViewModel KnownBusinessWebsiteProfile { get; set; }
     public List<KnownBusinessWebsiteAliasViewModel> KnownBusinessWebsiteAliases { get; set; } = new();
     public List<WebsitePageViewModel> WebsitePages { get; set; } = new();

} 
        