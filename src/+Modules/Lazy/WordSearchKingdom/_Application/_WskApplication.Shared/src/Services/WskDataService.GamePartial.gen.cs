// ag=no
namespace WskApplication.Shared.Services; 
public partial class WskHttpDataService
{
    public async Task<GameViewModel?> GameCheckWordCoordsAsync(GameCheckWordCoordsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameCreateNewAsync(GameCreateNewRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        // response.EnsureSuccessStatusCode();

        switch (response.StatusCode)
        {
            case System.Net.HttpStatusCode.OK:
                return await response
                    .Content
                    .ReadFromJsonAsync<GameViewModel>();
            case System.Net.HttpStatusCode.BadRequest:
                var error = await response
                    .Content
                    .ReadAsStringAsync();
                throw new ArgumentException(error);
            default:
                throw new ApplicationException(response.ReasonPhrase);
        }

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameGetByIdAsync(GameGetByIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }
    public async Task<GameViewModel?> GameRecreateGridAsync(GameRecreateGridRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<GameViewModel>();
    }

}
