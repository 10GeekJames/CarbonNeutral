namespace LiveRoomBlazorModule.UIUnitTests;
public class BaseTest
{
    protected TestContext ctx = new TestContext();

    public BaseTest()
    {
        var mockHttpClient = Mock.Create<HttpClient>();
        ctx.Services.AddSingleton<HttpClient>(mockHttpClient);

        var mockPlatformStateCacheService = Mock.Create<PlatformStateCacheService>();
        ctx.Services.AddSingleton<PlatformStateCacheService>(mockPlatformStateCacheService);

        var mockPlatformCacheService = Mock.Create<PlatformCacheService>();
        ctx.Services.AddSingleton<PlatformCacheService>(mockPlatformCacheService);

        var mockILayoutService = Mock.Create<ILayoutService>();
        ctx.Services.AddSingleton<ILayoutService>(mockILayoutService);

        var mockBrowserResizeService = Mock.Create<BrowserResizeService>();
        ctx.Services.AddSingleton<BrowserResizeService>(mockBrowserResizeService);

        var mockRandomizerService = Mock.Create<RandomizerService>();
        ctx.Services.AddSingleton<RandomizerService>(mockRandomizerService);

        var mockLazyModuleJsInterop = Mock.Create<LazyModuleJsInterop>();
        ctx.Services.AddSingleton<LazyModuleJsInterop>(mockLazyModuleJsInterop);

        var mockEndpoints = Mock.Create<Endpoints>();
        ctx.Services.AddSingleton<Endpoints>(mockEndpoints);

        var mockFeatureFlags = Mock.Create<FeatureFlags>();
        ctx.Services.AddSingleton<FeatureFlags>(mockFeatureFlags);

        var mockAppSettings = Mock.Create<AppSettings>();
        ctx.Services.AddSingleton<AppSettings>(mockAppSettings);

        var mockNavigationManager = Mock.Create<NavigationManager>();
        ctx.Services.AddSingleton<NavigationManager>(mockNavigationManager);

        var mockSnackbar = Mock.Create<ISnackbar>();
        ctx.Services.AddSingleton<ISnackbar>(mockSnackbar);

        var mockIStringLocalizer = Mock.Create<IStringLocalizer>();
        ctx.Services.AddSingleton<IStringLocalizer>(mockIStringLocalizer);

        var mockLocalizeShared = Mock.Create<IStringLocalizer<SharedLanguageBase>>();
        ctx.Services.AddSingleton<IStringLocalizer<SharedLanguageBase>>(mockLocalizeShared);

        var mockLocalizeModule = Mock.Create<IStringLocalizer<LiveRoomCoreLanguageBase>>();
        ctx.Services.AddSingleton<IStringLocalizer<LiveRoomCoreLanguageBase>>(mockLocalizeModule);

        var mockAllBooksPageLocalizer = Mock.Create<IStringLocalizer<AllBooks>>();
        ctx.Services.AddSingleton<IStringLocalizer<AllBooks>>(mockAllBooksPageLocalizer);

        var mockAllBooksComponentLocalizer = Mock.Create<IStringLocalizer<AllBooksComponent>>();
        ctx.Services.AddSingleton<IStringLocalizer<AllBooksComponent>>(mockAllBooksComponentLocalizer);

        // ------------------------------------

        // LiveRoomModule
        var mockILiveRoomDataService = Mock.Create<ILiveRoomDataService>();
        ctx.Services.AddSingleton<ILiveRoomDataService>(mockILiveRoomDataService);

        var mockLiveRoomHttpClientFactory = Mock.Create<LiveRoomHttpClientFactory>();
        ctx.Services.AddSingleton<LiveRoomHttpClientFactory>(mockLiveRoomHttpClientFactory);
        // \LiveRoomModule       

        ctx.Services.AddSingleton<LazyAssemblyLoader>();

    }
}