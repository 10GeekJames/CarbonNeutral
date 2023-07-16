
namespace WskApplication.Shared.Services;
public partial class WskModuleHttpDataService
{
    public async Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request){
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request){
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameRecreateGridAsync(GameRecreateGridRequest request){
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
}
