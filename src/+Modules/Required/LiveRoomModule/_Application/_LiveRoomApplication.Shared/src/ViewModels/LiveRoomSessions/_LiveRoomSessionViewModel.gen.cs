// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class LiveRoomSessionViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public Guid? KnownUserId { get; set; } = null;
     public LiveRoomSessionDifficulties LiveRoomSessionDifficulty { get; set; }
     public List<LiveRoomSessionCategoryViewModel> LiveRoomSessionCategories { get; set; } = new();
     public List<LiveRoomSessionTagViewModel> LiveRoomSessionTags { get; set; } = new();
     public LiveRoomSessionGridViewModel LiveRoomSessionGrid { get; set; }


} 
        