// ag=yes
namespace LiveRoomApi.Controllers; 
public partial class LiveRoomSessionsController : BaseController
{
    public LiveRoomSessionsController(IMediator mediator, IMapper mapper, ILiveRoomDataService dataService) : base(mediator, mapper, dataService) { }

}
