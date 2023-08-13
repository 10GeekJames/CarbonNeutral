// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class LiveRoomSessionCategoryViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public List<LiveRoomSessionViewModel> LiveRoomSessions { get; set; } = new();


} 
        