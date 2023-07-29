// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameCategoryViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public List<GameViewModel> Games { get; set; } = new();


} 
        