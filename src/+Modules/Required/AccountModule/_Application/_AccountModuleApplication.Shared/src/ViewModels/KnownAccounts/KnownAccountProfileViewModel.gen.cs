// ag=yes
namespace AccountModuleApplication.Shared.ViewModels; 
public partial class KnownAccountProfileViewModel : BaseViewModel<Guid>
{ 

     public Guid KnownAccountId { get; set; }
     public KnownAccountViewModel KnownAccount { get; set; }
     [MaxLength(101)]
     public string Name { get; set; } = String.Empty;

} 
        