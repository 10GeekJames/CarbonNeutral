// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownBusinessProfileViewModel : BaseViewModel<Guid>
{ 

     [MaxLength(101)]
     public string Name { get; set; } = String.Empty;
     public Guid KnownBusinessId { get; set; }
     public KnownBusinessViewModel KnownBusiness { get; set; }

} 
        