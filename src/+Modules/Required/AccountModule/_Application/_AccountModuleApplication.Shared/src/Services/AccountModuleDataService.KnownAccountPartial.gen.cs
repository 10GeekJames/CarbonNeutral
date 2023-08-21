// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownAccountViewModel?> KnownAccountAddAsync(KnownAccountAddRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownAccountViewModel>();
    }
    public async Task<KnownAccountViewModel?> KnownAccountGetByEmailAsync(KnownAccountGetByEmailRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownAccountViewModel>();
    }
    public async Task<KnownAccountViewModel?> KnownAccountGetByNameAsync(KnownAccountGetByNameRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownAccountViewModel>();
    }

}
