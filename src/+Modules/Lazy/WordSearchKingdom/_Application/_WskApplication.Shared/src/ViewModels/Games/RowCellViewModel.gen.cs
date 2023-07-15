// ag=yes
namespace WskApplication.Shared.ViewModels; 
public partial class RowCellViewModel : BaseViewModel<Guid>
{ 

     public string Pigment { get; set; } = String.Empty;
     public int X { get; set; }
     public int Y { get; set; }
     public char Letter { get; set; }

} 
        