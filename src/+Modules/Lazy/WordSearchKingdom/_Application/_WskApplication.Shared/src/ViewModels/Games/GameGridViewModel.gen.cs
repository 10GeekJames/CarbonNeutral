// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameGridViewModel : BaseViewModel<Guid>
{ 

     public int Height { get; set; } = 0;
     public int Width { get; set; } = 0;
     public List<HiddenWordViewModel> HiddenWords { get; set; } = new();

     public char[,]? RowCellsData { get; set; } 

     public string RowCellDataAsString 
     {
     get { return RowCellsData != null ? JsonConvert.SerializeObject(RowCellsData) : null; }
     set { RowCellsData = !string.IsNullOrWhiteSpace(value) ? JsonConvert.DeserializeObject<char[,]>(value) : null; }
     }

     public List<(int x, int y)>? CompletedWordCells { get; set; } 

     public string? CompletedWordCellsAsString 
     {
     get { return CompletedWordCells != null ? JsonConvert.SerializeObject(CompletedWordCells) : null; }
     set { CompletedWordCells = !string.IsNullOrWhiteSpace(value) ? JsonConvert.DeserializeObject<List<(int x, int y)>>(value) : new(); }
     }


} 
        