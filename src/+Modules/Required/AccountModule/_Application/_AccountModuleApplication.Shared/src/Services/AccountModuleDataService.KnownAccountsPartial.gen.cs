// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<List<KnownAccountViewModel>?> KnownAccountsGetAllAsync(KnownAccountsGetAllRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<KnownAccountViewModel>>();
    }

}
