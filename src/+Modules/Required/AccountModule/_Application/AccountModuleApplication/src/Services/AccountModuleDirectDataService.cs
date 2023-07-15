namespace AccountModuleApplication.Services;
public partial class AccountModuleDirectDataService : IAccountModuleDataService
{
    protected readonly IMediator _mediator;
    protected readonly IMapper _mapper;
    public AccountModuleDirectDataService(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }
}