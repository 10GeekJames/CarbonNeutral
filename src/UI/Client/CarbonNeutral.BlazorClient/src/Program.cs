var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
if (!builder.HostEnvironment.IsDevelopment())
{
    builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress.Replace("http:", "https:")) });
}

builder.Services.AddMudServices();

builder.Services.AddScoped<PlatformStateCacheService>();
builder.Services.AddScoped<PlatformCacheService>();

builder.Services.AddScoped<ILayoutService, LayoutService>();
builder.Services.AddSingleton<BrowserResizeService>();
builder.Services.AddSingleton<RandomizerService>();
builder.Services.AddSingleton<LazyModuleJsInterop>();

var appSettings = builder.Configuration.Get<AppSettings>();
var endPoints = appSettings!.Endpoints;
var featureFlags = appSettings!.FeatureFlags;

builder.Services.AddSingleton<Endpoints>(endPoints!);
builder.Services.AddSingleton<FeatureFlags>(featureFlags!);

builder.Services.AddOidcAuthentication(options =>
    {
        builder.Configuration.Bind("Oidc", options.ProviderOptions);
        options.ProviderOptions.Authority = appSettings.Endpoints.IdentityEndpointUrl;
        options.ProviderOptions.ClientId = "CarbonNeutralClient";
        options.ProviderOptions.ResponseType = "code";
        options.UserOptions.RoleClaim = "role";
        options.ProviderOptions.PostLogoutRedirectUri = "/Welcome";
        options.AuthenticationPaths.RemoteProfilePath = $"{appSettings.Endpoints.IdentityEndpointUrl}/Account/Manage";
        options.AuthenticationPaths.RemoteRegisterPath = $"{appSettings.Endpoints.IdentityEndpointUrl}/Account/Register";
        options.AuthenticationPaths.LogOutSucceededPath = "/Welcome";
    }).AddAccountClaimsPrincipalFactory<AccountClaimsPrincipalFactoryEx>();
builder.Services.AddScoped<CustomAuthorizationMessageHandler>();

/* builder.Services.AddGoogleAnalytics("G-WZSRLSH36B"); */

builder.RegisterLazyModules();
builder.RegisterRequiredModules();


// smash in all the resx files

builder.Services.AddLocalization();

builder.Services.AddApiAuthorization(options =>
{
    options.AuthenticationPaths.LogInPath = "Account/login";
    options.AuthenticationPaths.LogInCallbackPath = "Account/login-callback";
    options.AuthenticationPaths.LogInFailedPath = "Account/login-failed";
    options.AuthenticationPaths.LogOutPath = "Account/logout";
    options.AuthenticationPaths.LogOutCallbackPath = "Account/logout-callback";
    options.AuthenticationPaths.LogOutFailedPath = "Account/logout-failed";
    options.AuthenticationPaths.LogOutSucceededPath = "Account/logged-out";
    options.AuthenticationPaths.ProfilePath = "Account/profile";
    //options.AuthenticationPaths.RegisterPath = "Account/register";
});
List<CultureInfo> supportedLanguages = new List<CultureInfo>
            {
                new CultureInfo("en-US"),
                new CultureInfo("es-ES"),
                new CultureInfo("fr-FR"),
                new CultureInfo("ja"),
                new CultureInfo("ta"),
                new CultureInfo("ar-QA")
            };
var jsInterop = builder.Build().Services.GetRequiredService<IJSRuntime>();
var appLanguage = await jsInterop.InvokeAsync<string>("appCulture.get");
if (appLanguage != null)
{
    if (supportedLanguages.Count(rs => rs.Name == appLanguage) > 0)
    {
        CultureInfo cultureInfo = new CultureInfo(appLanguage);
        CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;
    }
}

// add in some mud blazor
builder.Services.AddMudServices(options =>
    {
        options.PopoverOptions.ThrowOnDuplicateProvider = false;
    });
/* builder.Services.Configure<AnimateOptions>("my", options =>
    {
    } 
);
 */
/* 
builder.Services.Configure<AnimateOptions>("my", options =>
    {
         opacity: 1;
  transition-property: opacity;
  &.aos-animate {
    opacity: 0;
  }
          options.Animation = Animations.FadeDown;
        options.Duration = TimeSpan.FromSeconds(2);
    }); */
// student add your code here 

var host = builder.Build();

var logger = host.Services.GetRequiredService<ILoggerFactory>()
    .CreateLogger<Program>();

logger.LogInformation("Logged after the app is built in Program.cs.");

await host.RunAsync();
