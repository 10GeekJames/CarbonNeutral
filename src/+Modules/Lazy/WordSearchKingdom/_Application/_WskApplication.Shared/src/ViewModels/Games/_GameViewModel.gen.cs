// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameViewModel : BaseViewModel<Guid>
{ 

     public string Title { get; set; } = String.Empty;
     public GameDifficulties GameDifficulty { get; set; }
     public GameGridViewModel GameGrid { get; set; }

} 
        