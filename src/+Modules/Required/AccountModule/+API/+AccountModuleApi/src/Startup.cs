
namespace AccountModuleApi;
public class Startup
{
    private readonly IWebHostEnvironment _env;
    public Startup(IConfiguration config, IWebHostEnvironment env)
    {
        Configuration = config;
        _env = env;
    }
    public IConfiguration Configuration { get; }
    public void ConfigureServices(IServiceCollection services)
    {
        //Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;       

        services
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        // default to AccountModuleAccountModuleConnectionString ENVVAR
        string connectionString =
            Configuration.GetConnectionString("Active"); //Configuration.GetConnectionString("DefaultConnection");
        var appSettings = Configuration.Get<AppSettings>();
        services.AddSingleton<AppSettings>(appSettings);
        services.AddAutoMapper(typeof(KnownAccountMap).GetTypeInfo().Assembly);
        foreach (var seedData in Assembly
                   .GetExecutingAssembly()
                   .GetTypes()
                   .Where(x => x.IsAssignableTo(typeof(IAccountModuleSeedScript)) && x.IsClass)
                   .OrderBy(rs => rs.Name))
        {
            services.AddSingleton(seedData);
        }

        services.AddAccountModuleDbContext(connectionString);
        services.AddSingleton<IAccountModuleDataService, AccountModuleDirectDataService>();
        services.AddHttpContextAccessor();
        /* services
            .AddControllersWithViews()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler =  ReferenceHandler.Preserve;
            });
        services.AddRazorPages()
        .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.ReferenceHandler =  ReferenceHandler.Preserve;
            });
 */
        services
            .AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;
                //options.SerializerSettings.MaxDepth = 2;
            });
        services.AddCors(opt =>
            {
                opt
                    .AddDefaultPolicy(builder =>
                    {
                        builder
                            .WithOrigins("https://WordSearchKingdom.com", "http://WordSearchKingdom.com:5020", "http://localhost:5020")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("*");
                    });
            });
        if (_env.EnvironmentName == "Development" || 1 == 1)
        {
            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo { Title = "My API", Version = "v1" });
                    c.EnableAnnotations();
                });
            services
                .Configure<ServiceConfig>(config =>
                {
                    config.Services = new List<ServiceDescriptor>(services);
                    config.Path = "/listservices";
                });
        }
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Startup).Assembly));
        services
            .AddAuthentication("Bearer")
            .AddJwtBearer("Bearer",
                options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.Authority = appSettings.Endpoints.IdentityEndpointUrl;
                    options.MetadataAddress = $"{appSettings.Endpoints.IdentityEndpointUrl}/.well-known/openid-configuration";
                    options.Audience = "CarbonNeutralClient_api_swaggerui";
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateAudience = false,
                        ValidIssuer = $"{appSettings.Endpoints.IdentityValidIssuer}"
                    };
                }
            )
        ;
        services
        .AddAuthorization(options =>
        {
        });



    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        builder.RegisterModule(new AccountModuleCoreModule());

        builder
            .RegisterModule(new AccountModuleInfrastructureModule(_env
                    .EnvironmentName ==
                "Development"));

        builder.RegisterModule(new AccountModuleDataModule(_env
                   .EnvironmentName ==
               "Development"));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.EnvironmentName == "Development")
        {
            app.UseDeveloperExceptionPage();
            app.UseShowAllServicesMiddleware();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAuthorization();
        // app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseSwagger();
        // Enable middleware to serve generated Swagger as a JSON endpoint.
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
        app
            .UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        app
            .UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
    }
}
