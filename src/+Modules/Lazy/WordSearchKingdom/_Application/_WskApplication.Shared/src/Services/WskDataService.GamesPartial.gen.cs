// ag=yes
namespace WskApplication.Shared.Services; 
public partial class WskHttpDataService
{
    public async Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel?>();
    }
    public async Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel?>();
    }
    public async Task<GameViewModel?> GameRecreateGridAsync(GameRecreateGridRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel?>();
    }
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<GameViewModel>?>();
    }

}
