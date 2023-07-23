// ag=yes
namespace WskApplication.Shared.Automaps; 
public partial class RowCellMap : Profile
{ 
    public override string ProfileName => "RowCellMap";
    
    public RowCellMap()
    {
        CreateMap<RowCell, RowCellViewModel>()
        .ReverseMap();
    }
}