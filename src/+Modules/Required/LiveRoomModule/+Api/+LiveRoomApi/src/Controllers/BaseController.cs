namespace LiveRoomApi.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class BaseController : ControllerBase
{
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;
    protected readonly ILiveRoomDataService _dataService;
    public BaseController(IMediator mediator, IMapper mapper, ILiveRoomDataService dataService)
    {
        _mediator = mediator;
        _mapper = mapper;
        _dataService = dataService;
    }
}
