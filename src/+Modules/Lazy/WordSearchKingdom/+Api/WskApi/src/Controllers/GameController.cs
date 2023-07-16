namespace WskApi.Controllers;

public class GameController : BaseController
{
    public GameController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }

    [HttpGet]
    public async Task<IActionResult> GetById([FromQuery]GameGetByIdQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateNew([FromBody]GameCreateNewCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> RecreateGrid([FromBody]GameRecreateGridCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }
}
