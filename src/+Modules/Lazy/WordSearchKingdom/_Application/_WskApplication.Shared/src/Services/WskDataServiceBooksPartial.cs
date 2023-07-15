
namespace WskApplication.Shared.Services;
public partial class WskModuleHttpDataService
{
    public async Task<List<BookViewModel>?> BooksGetAllAsync(BooksGetAllQry qry)
    {
        var response = await _httpClient.GetAsync(BooksGetAllRequest.BuildRoute());

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<BookViewModel>>();
    }

     public async Task<BookViewModel?> BookAddAsync(BookAddCmd cmd)
    {
        var response = await _httpClient.PostAsJsonAsync(BookAddRequest.BuildRoute(), cmd);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<BookViewModel>();
    }

     public async Task<List<BookViewModel>?> BooksFindAsync(BooksFindQry qry)
    {
        var response = await _httpClient.PostAsJsonAsync(BooksFindRequest.BuildRoute(qry), qry);

        response.EnsureSuccessStatusCode();

        return await response
            .Content
            .ReadFromJsonAsync<List<BookViewModel>>();
    }
}
