// ag=yes
namespace AccountModuleApplication.Shared.Services; 
public partial class AccountModuleHttpDataService
{
    public async Task<KnownBusinessViewModel?> KnownBusinessAddChildBusinessAsync(KnownBusinessAddChildBusinessRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessViewModel>();
    }
    public async Task<KnownBusinessViewModel?> KnownBusinessGetByIdAsync(KnownBusinessGetByIdRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<KnownBusinessViewModel>();
    }
    public async Task<List<KnownBusinessViewModel>?> KnownBusinessGetChildBusinessesAsync(KnownBusinessGetChildBusinessesRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<KnownBusinessViewModel>>();
    }

}
