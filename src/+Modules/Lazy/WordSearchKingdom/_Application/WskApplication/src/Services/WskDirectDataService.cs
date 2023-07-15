namespace WskApplication.Services;
public partial class WskDirectDataService : IWskDataService
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;
    public WskDirectDataService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}