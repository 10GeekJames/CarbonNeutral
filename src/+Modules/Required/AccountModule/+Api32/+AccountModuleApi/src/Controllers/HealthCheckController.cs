namespace AccountModuleApi
{
    public class HealthCheckController : BaseController
    {
        public HealthCheckController(IMediator mediator, IMapper mapper, IAccountModuleDataService dataService) : base(mediator, mapper, dataService) { }
    
        [HttpGet]
        public string Get()
        {
            DateTime dat = new DateTime(2009, 6, 15, 13, 45, 30,
                                   DateTimeKind.Unspecified);
            return $"The date time is {String.Format("{0} ({1}) --> {0:O}", dat, dat.Kind)}";
        }
    }
}
