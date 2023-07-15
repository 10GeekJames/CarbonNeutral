// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameTagViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public List<GameTagViewModel> GameTags { get; set; } = new();

} 
        