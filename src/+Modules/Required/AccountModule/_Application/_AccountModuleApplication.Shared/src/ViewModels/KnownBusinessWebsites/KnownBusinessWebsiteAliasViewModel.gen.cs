// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownBusinessWebsiteAliasViewModel : BaseViewModel<Guid>
{ 

     public KnownBusinessWebsiteViewModel KnownBusinessWebsite { get; set; }
     public string Url { get; set; } = String.Empty;
     public string Name { get; set; } = String.Empty;
     public bool IsActive { get; set; } = true;

} 
        