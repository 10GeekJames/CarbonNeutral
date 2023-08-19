namespace CarbonNeutral.KernelShared.Configuration;
public class Endpoints
{
    public string IdentityEndpointUrl { get; set; } = "";
    public string IdentityValidIssuer { get; set; } = "";

    public string PubsubEndpointUrl { get; set; } = "";

    public string AccountApiUrl { get; set; } = "";
    public string AccountApiVersion { get; set; } = "";
    public string AccountApiName { get; set; } = "wsk_api";

    public string AccountAdminApiUrl { get; set; } = "";
    public string AccountAdminApiVersion { get; set; } = "";
    public string AccountAdminApiName { get; set; } = "wsk_admin_api";
    
    public string WskApiUrl { get; set; } = "";
    public string WskApiVersion { get; set; } = "";
    public string WskApiName { get; set; } = "wsk_api";
    
    public string WskAdminApiUrl { get; set; } = "";
    public string WskAdminApiVersion { get; set; } = "";
    public string WskAdminApiName { get; set; } = "wsk_admin_api";


    public string LiveRoomApiUrl { get; set; } = "";
    public string LiveRoomApiVersion { get; set; } = "";
    public string LiveRoomApiName { get; set; } = "liveroom_api";
    
    public string LiveRoomAdminApiUrl { get; set; } = "";
    public string LiveRoomAdminApiVersion { get; set; } = "";
    public string LiveRoomAdminApiName { get; set; } = "liveroom_admin_api";

    
}
