// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class HiddenWordViewModel : BaseViewModel<Guid>
{ 

     public string Word { get; set; } = String.Empty;
     public bool IsFound { get; set; } = false;


} 
        