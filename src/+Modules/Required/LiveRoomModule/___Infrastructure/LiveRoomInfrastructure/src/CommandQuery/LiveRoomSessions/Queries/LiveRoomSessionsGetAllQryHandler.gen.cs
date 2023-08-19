// ag=no
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionsGetAllQryHandler : IRequestHandler<LiveRoomSessionsGetAllQry, List<LiveRoomSession>>
{
    private IRepository<LiveRoomSession> _repository;
    public LiveRoomSessionsGetAllQryHandler(IRepository<LiveRoomSession> repository) 
    {
        _repository = repository;
    }

    public async Task<List<LiveRoomSession>> Handle(LiveRoomSessionsGetAllQry qry, CancellationToken cancellationToken)
    {
        var spec = new LiveRoomSessionsGetAllSpec(qry.KnownUserId.Value);
        return await _repository.ListAsync(spec, cancellationToken);
    }
}