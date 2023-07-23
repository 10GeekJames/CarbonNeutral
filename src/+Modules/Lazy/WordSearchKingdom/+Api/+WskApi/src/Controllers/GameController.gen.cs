// ag=yes
namespace WskApi.Controllers; 
public partial class GameController : BaseController
{
    public GameController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> CheckWordCoords(GameCheckWordCoordsQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> CreateNew(GameCreateNewCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> GetById(GameGetByIdQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }
    [HttpPost]
    public async Task<IActionResult> RecreateGrid(GameRecreateGridCmd cmd)
    {
        var result = await _mediator.Send(cmd);
        var response = _mapper.Map<GameViewModel>(result);
        return Ok(response);
    }

}
