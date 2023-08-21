// ag=yes
namespace WskApi.Controllers; 
public partial class GameController : BaseController
{
    public GameController(IMediator mediator, IMapper mapper, IWskDataService dataService) : base(mediator, mapper, dataService) { }

}
