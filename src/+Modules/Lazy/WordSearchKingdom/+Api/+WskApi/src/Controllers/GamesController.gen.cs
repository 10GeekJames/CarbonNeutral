// ag=yes
namespace WskApi.Controllers; 
public partial class GamesController : BaseController
{
    public GamesController(IMediator mediator, IMapper mapper, IWskDataService dataService) : base(mediator, mapper, dataService) { }

}
