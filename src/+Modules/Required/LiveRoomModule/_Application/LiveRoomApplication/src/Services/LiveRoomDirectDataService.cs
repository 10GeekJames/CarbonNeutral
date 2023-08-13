namespace LiveRoomApplication.Services;
public partial class LiveRoomDirectDataService : ILiveRoomDataService, ILiveRoomDataServiceNotAuthed
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public LiveRoomDirectDataService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}