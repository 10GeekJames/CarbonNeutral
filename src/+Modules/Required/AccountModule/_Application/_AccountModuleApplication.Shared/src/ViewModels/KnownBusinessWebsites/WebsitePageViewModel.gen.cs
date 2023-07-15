// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class WebsitePageViewModel : BaseViewModel<Guid>
{ 

     public Guid? WebsiteParentPageId { get; set; } = null;
     public WebsitePageViewModel? WebsiteParentPage { get; set; } = null;
     [MaxLength(1000)]
     public string WebsitePageContent { get; set; } = String.Empty;
     public List<WebsitePageViewModel> WebsiteChildPages { get; set; } = new();
     public KnownBusinessWebsiteViewModel? KnownBusinessWebsite { get; set; } = null;
     public List<WebsitePageContentViewModel> WebsitePageContents { get; set; } = new();
     [MaxLength(1000)]
     public string WebPageUrl { get; set; } = String.Empty;
     public bool IsVirtual { get; set; } = true;
     public bool IsInNavigation { get; set; } = false;
     [MaxLength(100)]
     public string PageTitle { get; set; } = "";
     [MaxLength(100)]
     public string NavText { get; set; } = "";
     [MaxLength(100)]
     public string NavIcon { get; set; } = "";

} 
        