using System;
using System.Reflection;
namespace WskApi;
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

        string dbConnectionStrategy = Configuration.GetValue<string>("WskDbUse") ?? "";
        string connectionString = Configuration.GetConnectionString(dbConnectionStrategy) ?? "";

        var appSettings = Configuration.Get<AppSettings>();

        services.AddSingleton<AppSettings>(appSettings!);

        if (dbConnectionStrategy.Contains("Sqlite", StringComparison.OrdinalIgnoreCase))
        {
            services.AddWskSqliteDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Memory", StringComparison.OrdinalIgnoreCase))
        {
            services.AddWskInMemoryDbContext(connectionString);
        }
        else if (dbConnectionStrategy.Contains("Sql", StringComparison.OrdinalIgnoreCase))
        {
            services.AddWskSqlDbContext(connectionString);
        }

        services
            .AddScoped<IWskDataService, WskDirectDataService>();

        services
            .AddScoped<IWskDataServiceNotAuthed, WskDirectDataService>();

        foreach (var seedData in Assembly
                   .GetExecutingAssembly()
                   .GetTypes()
                   .Where(x => x.IsAssignableTo(typeof(IWskSeedScript)) && x.IsClass)
                   .OrderBy(rs => rs.Name))
        {
            services.AddSingleton(seedData);
        }

        // services.AddDbContext<WskDbContext>(options =>
        //     options.UseSqlite(connectionString, b => b.MigrationsAssembly("WskApplication.Data")));

        services
            .Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

        services
            .AddControllersWithViews()
            .AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver =
                    new CamelCasePropertyNamesContractResolver();
                options.SerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;
                /*options.SerializerSettings.Converters.Add(
                    new StronglyTypedIdNewtonsoftJsonConverter());*/
                //options.SerializerSettings.MaxDepth = 2;
            });

        services
            .AddRazorPages();

        services
            .AddCors(opt =>
            {
                opt
                    .AddDefaultPolicy(builder =>
                    {
                        builder
                            //.WithOrigins("https://WordSearchKingdom.com", "http://WordSearchKingdom.com:5020", "http://localhost:5020")
                            .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .WithExposedHeaders("*");
                    });
            })
            .AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                    "v1",
                        new OpenApiInfo
                        {
                            Title = appSettings!.Endpoints.WskApiName,
                            Version = appSettings!.Endpoints.WskApiVersion
                        });
                c.EnableAnnotations();
            });

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
        builder.RegisterModule(new WskCoreModule());
        builder.RegisterModule(new WskInfrastructureModule(isInDevelopment));
        //builder.RegisterModule(new WskApplicationSharedModule(isInDevelopment));
        builder.RegisterModule(new WskApiModule(isInDevelopment));
    }
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.EnvironmentName == "Development")
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }
        app.UseRouting();
        // app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseCookiePolicy();
        app.UseCors();

        app.UseAuthentication();
        app.UseAuthorization();

        // Enable middleware to serve generated Swagger as a JSON endpoint.
        app.UseSwagger();
        // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
        app
            .UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));
        app
            .UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
    }
}