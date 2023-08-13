// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class LiveRoomSessionTagViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public List<LiveRoomSessionViewModel> LiveRoomSessions { get; set; } = new();


} 
        