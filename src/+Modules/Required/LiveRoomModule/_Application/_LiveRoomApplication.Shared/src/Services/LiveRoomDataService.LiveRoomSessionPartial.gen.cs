// ag=yes
namespace LiveRoomApplication.Shared.Services; 
public partial class LiveRoomHttpDataService
{
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionCheckWordCoordsAsync(LiveRoomSessionCheckWordCoordsRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<LiveRoomSessionViewModel>();
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionCreateNewAsync(LiveRoomSessionCreateNewRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<LiveRoomSessionViewModel>();
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionGetByIdAsync(LiveRoomSessionGetByIdRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<LiveRoomSessionViewModel>();
    }
    public async Task<LiveRoomSessionViewModel?> LiveRoomSessionRecreateGridAsync(LiveRoomSessionRecreateGridRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(request.BuildRouteFrom(), request);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<LiveRoomSessionViewModel>();
    }

}
