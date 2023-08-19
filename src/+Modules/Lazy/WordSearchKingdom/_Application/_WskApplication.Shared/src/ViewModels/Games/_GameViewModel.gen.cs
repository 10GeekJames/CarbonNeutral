// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public Guid KnownUserId { get; set; }
     public int Height { get; set; } = 0;
     public int Width { get; set; } = 0;
     public GameDifficulties GameDifficulty { get; set; }
     public List<GameCategoryViewModel> GameCategories { get; set; } = new();
     public List<GameTagViewModel> GameTags { get; set; } = new();
     public List<GameGridViewModel> GameGrids { get; set; } = new();
     public List<HiddenWordViewModel> HiddenWords { get; set; } = new();

     public GameGridViewModel? GameGrid => GameGrids.FirstOrDefault(); 


} 
        