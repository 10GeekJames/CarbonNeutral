// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public Guid? KnownUserId { get; set; } = null;
     public GameDifficulties GameDifficulty { get; set; }
     public List<GameCategoryViewModel> GameCategories { get; set; } = new();
     public List<GameTagViewModel> GameTags { get; set; } = new();
     public GameGridViewModel GameGrid { get; set; }


} 
        