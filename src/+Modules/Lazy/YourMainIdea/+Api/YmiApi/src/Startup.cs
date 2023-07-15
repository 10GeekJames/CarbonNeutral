namespace YmiApi;
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

        string connectionString =
            Configuration.GetConnectionString("Active") ?? "";

        var appSettings = Configuration.Get<AppSettings>();
        
        services
            .AddSingleton<AppSettings>(appSettings!);
        
        services
            .AddYmiDbContext(connectionString);
        // services.AddDbContext<YmiDbContext>(options =>
        //     options.UseSqlite(connectionString, b => b.MigrationsAssembly("YmiApplication.Data")));

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
                            Title = appSettings!.Endpoints.YmiApiName,
                            Version = appSettings!.Endpoints.YmiApiVersion
                        });
                c.EnableAnnotations();
            });



        /* 
    services
        .AddAuthentication("Bearer")
    services
        .AddJwtBearer("Bearer",
            options =>
            {
                options.RequireHttpsMetadata = false;
                options.Authority = appSettings.ConfigEndpoints.IdentityEndpointUrl;
                options.MetadataAddress = $"{appSettings.ConfigEndpoints.IdentityEndpointUrl}/.well-known/openid-configuration";
                options.Audience = "ymi_primary_api_swaggerui";
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidIssuer = appSettings.ConfigEndpoints.IdentityValidIssuer
                };
            })

        .AddAuthorization(options => { })
        */
        ;
    }
    public void ConfigureContainer(ContainerBuilder builder)
    {
        var isInDevelopment = _env.EnvironmentName == "Development";
        builder.RegisterModule(new YmiCoreModule());
        builder.RegisterModule(new YmiInfrastructureModule(isInDevelopment));
        builder.RegisterModule(new YmiApplicationModule(isInDevelopment));
        builder.RegisterModule(new YmiApiModule(isInDevelopment));
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

        //app.UseAuthentication();
        //app.UseAuthorization();

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