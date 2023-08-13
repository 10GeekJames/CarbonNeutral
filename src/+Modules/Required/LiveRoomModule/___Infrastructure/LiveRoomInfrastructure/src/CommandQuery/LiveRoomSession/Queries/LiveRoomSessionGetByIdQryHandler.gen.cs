// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public partial class LiveRoomSessionGetByIdQryHandler : IRequestHandler<LiveRoomSessionGetByIdQry, LiveRoomSession>
{
    private IRepository<LiveRoomSession> _repository;
    public LiveRoomSessionGetByIdQryHandler(IRepository<LiveRoomSession> repository) 
    {
        _repository = repository;
    }

    public async Task<LiveRoomSession> Handle(LiveRoomSessionGetByIdQry qry, CancellationToken cancellationToken)
    {
        var spec = new LiveRoomSessionGetByIdSpec(qry.Id);
        var rs = await _repository.FirstOrDefaultAsync(spec, cancellationToken);
        return rs;
    }
}