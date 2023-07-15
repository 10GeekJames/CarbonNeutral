// ag=yes
namespace AccountModuleInfrastructure.CommandQuery; 
public partial class KnownBusinessWebsiteGetByUrlQry : IRequest<KnownBusinessWebsite>
{
    public string Url {get;set;}
    public KnownBusinessWebsiteGetByUrlQry(string url) {
        Url = Guard.Against.NullOrEmpty(url);
    }
}
