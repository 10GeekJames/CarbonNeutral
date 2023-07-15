// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class WebsitePageContentViewModel : BaseViewModel<Guid>
{ 

     public WebsitePageViewModel WebsitePage { get; set; }
     [MaxLength(65535)]
     public string HtmlContent { get; set; } = "";

} 
        