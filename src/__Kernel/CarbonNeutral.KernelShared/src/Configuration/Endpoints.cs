namespace CarbonNeutral.KernelShared.Configuration;
public class Endpoints
{
    public string IdentityEndpointUrl { get; set; } = "";
    public string IdentityValidIssuer { get; set; } = "";

    public string PubsubEndpointUrl { get; set; } = "";

    public string AccountAdminApiUrl { get; set; } = "";
    public string AccountAdminApiVersion { get; set; } = "";
    public string AccountAdminApiName { get; set; } = "wsk_admin_api";
    
    public string WskApiUrl { get; set; } = "";
    public string WskApiVersion { get; set; } = "";
    public string WskApiName { get; set; } = "wsk_api";
    
    public string WskAdminApiUrl { get; set; } = "";
    public string WskAdminApiVersion { get; set; } = "";
    public string WskAdminApiName { get; set; } = "wsk_admin_api";

    
}
