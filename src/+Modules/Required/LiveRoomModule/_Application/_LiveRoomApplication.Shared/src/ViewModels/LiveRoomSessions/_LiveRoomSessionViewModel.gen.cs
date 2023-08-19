// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class LiveRoomSessionViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public string Slug { get; set; } = String.Empty;
     public Guid? KnownUserId { get; set; } = null;


} 
        