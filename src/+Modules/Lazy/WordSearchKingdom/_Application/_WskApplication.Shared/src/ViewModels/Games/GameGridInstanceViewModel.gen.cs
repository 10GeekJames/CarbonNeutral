// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameGridInstanceViewModel : BaseViewModel<Guid>
{ 

     public string? Title { get; set; } = null;
     public GameGridViewModel GameGrid { get; set; }
     public Guid KnownUserId { get; set; }
     public string CompletedWordCellData { get; set; } = "";
     public List<string> CompletedWordsDataArray { get; set; } = new();
     public string CompletedWordsData { get; set; } = "";


} 
        