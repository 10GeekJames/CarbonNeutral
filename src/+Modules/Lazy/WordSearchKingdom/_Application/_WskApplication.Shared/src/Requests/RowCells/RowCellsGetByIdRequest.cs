namespace WskApplication.Shared.Requests;

public class RowCellsGetByIdRequest : IRoutable
{
    protected readonly static string Route = "rowcell/getbyid?id={Guid:Id}";
    public Guid Id { get; set; }
    public RowCellsGetByIdRequest() {}
    public RowCellsGetByIdRequest(Guid id)
    {
        Id = id;
    }
    public string BuildRouteFrom() => RowCellsGetByIdRequest.BuildRoute(Id);
    public static string BuildRoute(Guid id) => Route.Replace("{Guid:Id}", id.ToString());
}
