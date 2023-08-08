using System.Security.AccessControl;

namespace AccountModuleApi;
public class Startup
{
    private readonly IWebHostEnvironment _env;
    public IConfiguration Configuration { get; }
    public Startup(IConfiguration configuration, IWebHostEnvironment env)
    {
        Configuration = configuration;
        _env = env;
    }
    
    public void ConfigureServices(IServiceCollection services)
    {
        Microsoft.IdentityModel.Logging.IdentityModelEventSource.ShowPII = true;       
        services
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        // default to AccountModuleAccountModuleConnectionString ENVVAR
        string dbConnectionStrategy = Configuration.GetValue<string>("AccountModuleDbUse") ?? "";
        string connectionString = Configuration.GetConnectionString(dbConnectionStrategy) ?? "";

        var appSettings = Configuration.Get<AppSettings>();        
        services.AddSingleton<AppSettings>(appSettings);

        services.AddAutoMapper(typeof(KnownAccountMap).GetTypeInfo().Assembly);
        
        if (dbConnectionStrategy.Contains("Sqlite", StringComparison.OrdinalIgnoreCase))
        {
            services.AddAccountModuleSqliteDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Memory", StringComparison.OrdinalIgnoreCase))
        {
            services.AddAccountModuleInMemoryDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Sql", StringComparison.OrdinalIgnoreCase))
        {
            services.AddAccountModuleSqlDbContext(connectionString);
        }        
        services.AddSingleton<IAccountModuleDataService, AccountModuleDirectDataService>();
        services.AddSingleton<IAccountModuleDataServiceNotAuthed, AccountModuleDirectDataService>();
        Console.WriteLine($"dbConnectionStrategy: {dbConnectionStrategy}, connectionString: {connectionString}");
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
                            //.WithOrigins("https://wordsearchkingdom.com", "http://WordSearchKingdom.com:5020", "http://localhost:5020")
                            .AllowAnyOrigin()
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
        var isInDevelopment = _env.EnvironmentName == "Development";
        builder.RegisterModule(new AccountModuleCoreModule());
        builder.RegisterModule(new AccountModuleInfrastructureModule(isInDevelopment));
        //builder.RegisterModule(new AccountModuleApplicationSharedModule(isInDevelopment));
        builder.RegisterModule(new AccountModuleApiModule(isInDevelopment));
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
