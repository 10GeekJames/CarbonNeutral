namespace AccountModuleApplication.Shared.Services;
public partial class AccountModuleHttpDataService : IAccountModuleDataService
{
    protected readonly HttpClient _httpClient;

    public AccountModuleHttpDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<KnownAccountViewModel> KnownAccountByNameAsync(string name)
    {
        var cmd = new KnownAccountGetByNameRequest(name);
        var response = await _httpClient.GetAsync(KnownAccountGetByNameRequest.BuildRoute(name));
        response.EnsureSuccessStatusCode();
        return await response
            .Content
            .ReadFromJsonAsync<KnownAccountViewModel>();
    }
    public async Task<List<KnownAccountViewModel>> AccountModuleListAsync()
    {
        var response = await _httpClient.GetAsync(KnownAccountGetAllRequest.BuildRoute());
        response.EnsureSuccessStatusCode();
        return await response
            .Content
            .ReadFromJsonAsync<List<KnownAccountViewModel>>();
    }
    public async Task<KnownAccountViewModel> KnownAccountAddAsync(KnownAccountAddRequest request)
    {
        var cmd = new KnownAccountAddRequest(request.AliasName, request.EmailAddress);
        var response = await _httpClient.PostAsJsonAsync(KnownAccountAddRequest.BuildRoute(), cmd);
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<KnownAccountViewModel>();
    }
    public async Task<List<KnownAccountViewModel>> KnownAccountAllAsync()
    {
        var response = await _httpClient.GetAsync(KnownAccountGetAllRequest.BuildRoute());
        response.EnsureSuccessStatusCode();
        
        var result = await response.Content.ReadFromJsonAsync<List<KnownAccountViewModel>>() ?? new List<KnownAccountViewModel>();
        return result;
    }
    public async Task<KnownBusinessWebsiteViewModel> KnownBusinessWebsiteGetAsync()
    {
        var response = await _httpClient.GetAsync(KnownBusinessWebsiteGetByUrlRequest.BuildRoute());
        response.EnsureSuccessStatusCode();
        KnownBusinessWebsiteViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
        }
        return vm;
    }
    public async Task<WebsitePageViewModel> WebsitePageGetByUrlAsync(WebsitePageGetByUrlRequest request)
    {
        var response = await _httpClient.GetAsync(WebsitePageGetByUrlRequest.BuildRoute(request.Url));
        response.EnsureSuccessStatusCode();
        WebsitePageViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            var businessWebsite = await response.Content.ReadFromJsonAsync<KnownBusinessWebsiteViewModel>();
            vm = businessWebsite.WebsitePages.FirstOrDefault();
        }
        return vm;
    }
    public async Task<WebsitePageViewModel> WebsitePageUpdateAsync(WebsitePageUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(WebsitePageUpdateRequest.BuildRoute(), request);
        response.EnsureSuccessStatusCode();
        WebsitePageViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<WebsitePageViewModel>();
        }
        return vm;
    }

    public async Task KnownBusinessWebsiteProfileUpdateAsync(KnownBusinessWebsiteProfileUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(KnownBusinessWebsiteProfileUpdateRequest.BuildRoute(), request);
        response.EnsureSuccessStatusCode();

        return;
    }

    public async Task KnownBusinessWebsiteUpdateAsync(KnownBusinessWebsiteUpdateRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(KnownBusinessWebsiteUpdateRequest.BuildRoute(), request);
        response.EnsureSuccessStatusCode();
    }

    public async Task<KnownUserViewModel> KnownUserGetAsync()
    {
        var response = await _httpClient.GetAsync(KnownUserGetRequest.BuildRoute());
        response.EnsureSuccessStatusCode();
        KnownUserViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<KnownUserViewModel>();
        }
        return vm;
    }
    public async Task<KnownBusinessViewModel> KnownBusinessAsync(KnownBusinessGetByIdRequest request)
    {
        var response = await _httpClient.GetAsync(KnownBusinessGetByIdRequest.BuildRoute(request.Id));
        response.EnsureSuccessStatusCode();
        KnownBusinessViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<KnownBusinessViewModel>();
        }
        return vm;
    }
    public async Task<IEnumerable<KnownBusinessViewModel>> KnownBusinessGetChildBusinessesAsync(KnownBusinessGetChildBusinessesRequest request)
    {
        var response = await _httpClient.GetAsync(KnownBusinessGetChildBusinessesRequest.BuildRoute(request.Id));
        response.EnsureSuccessStatusCode();
        List<KnownBusinessViewModel> vm = new();
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<List<KnownBusinessViewModel>>();
        }
        return vm;
    }
    public async Task<KnownUserViewModel> KnownUserUpdateAccountAsync(KnownUserUpdateAccountRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync(KnownUserUpdateAccountRequest.BuildRoute(), request);
        response.EnsureSuccessStatusCode();
        KnownUserViewModel vm = null;
        if (response.StatusCode != HttpStatusCode.NoContent)
        {
            vm = await response.Content.ReadFromJsonAsync<KnownUserViewModel>();
        }
        return vm;
    }
}
