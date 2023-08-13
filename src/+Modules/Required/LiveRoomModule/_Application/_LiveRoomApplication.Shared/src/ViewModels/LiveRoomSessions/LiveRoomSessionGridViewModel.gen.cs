// ag=yes
namespace LiveRoomApplication.Shared.ViewModels; 
public partial class LiveRoomSessionGridViewModel : BaseViewModel<Guid>
{ 

     public int Height { get; set; } = 0;
     public int Width { get; set; } = 0;
     public List<HiddenWordViewModel> HiddenWords { get; set; } = new();
     public string RowCellData { get; set; } = "";
     public string CompletedWordCellData { get; set; } = "";


} 
        