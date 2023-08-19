// ag=no
namespace WskApplication.Shared.ViewModels; 
public partial class GameGridViewModel : BaseViewModel<Guid>
{ 

     public GameViewModel Game { get; set; }
     public List<GameGridInstanceViewModel> GameGridInstances { get; set; } = new();
     public GameGridInstanceViewModel? GameGridInstance => GameGridInstances.FirstOrDefault();
     public bool IsCurrent { get; set; } = true;
     public string RowCellData { get; set; } = "";


} 
        