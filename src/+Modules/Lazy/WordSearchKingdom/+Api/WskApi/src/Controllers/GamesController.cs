namespace WskApi.Controllers;

public class GamesController : BaseController
{
    public GamesController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var qry = new GamesGetAllQry();
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<IEnumerable<GameViewModel>>(result);
        return Ok(response);
    }
}
