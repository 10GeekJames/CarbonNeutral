namespace YmiApplication.Services;
public partial class YmiDirectDataService : IYmiDataService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public YmiDirectDataService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}