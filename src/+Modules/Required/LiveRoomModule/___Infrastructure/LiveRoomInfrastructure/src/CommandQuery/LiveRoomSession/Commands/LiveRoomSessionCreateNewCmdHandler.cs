// ag=yes
namespace LiveRoomInfrastructure.CommandQuery; 
public class LiveRoomSessionCreateNewCmdHandler : IRequestHandler<LiveRoomSessionCreateNewCmd, LiveRoomSession>
{
    private IRepository<LiveRoomSession> _repository;
    public LiveRoomSessionCreateNewCmdHandler(IRepository<LiveRoomSession> repository) 
    {
        _repository = repository;
    }

    public async Task<LiveRoomSession> Handle(LiveRoomSessionCreateNewCmd cmd, CancellationToken cancellationToken)
    {
        var liveRoomSession = new LiveRoomSession(cmd.Slug, cmd.Title, cmd.KnownUserId);
        await _repository.AddAsync(liveRoomSession);
        return liveRoomSession;
    }
}