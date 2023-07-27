// ag=yes
namespace WskApplication.Shared.Services; 
public partial class WskHttpDataService
{
    public async Task<List<GameViewModel>?> GamesGetAllAsync(GamesGetAllRequest request)
    {
        var response = await _httpClient.GetAsync(request.BuildRouteFrom());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<GameViewModel>>();
    }

}
