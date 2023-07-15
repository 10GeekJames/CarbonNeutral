// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class GameGridViewModel : BaseViewModel<Guid>
{ 

     public int Height { get; set; }
     public int Width { get; set; }
     public List<HiddenWordViewModel> HiddenWords { get; set; } = new();
     public List<RowCellViewModel> RowCells { get; set; } = new();

} 
        