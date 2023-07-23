// ag=yes
namespace WskApi.Controllers; 
public partial class GamesController : BaseController
{
    public GamesController(IMediator mediator, IMapper mapper) : base(mediator, mapper) { }
    [HttpPost]
    public async Task<IActionResult> GetAll(GamesGetAllQry qry)
    {
        var result = await _mediator.Send(qry);
        var response = _mapper.Map<List<GameViewModel>>(result);
        return Ok(response);
    }

}
