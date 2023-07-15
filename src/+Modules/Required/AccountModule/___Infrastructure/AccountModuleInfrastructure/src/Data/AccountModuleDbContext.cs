namespace AccountModuleInfrastructure.Data;
public class AccountModuleDbContext : DbContext
{
    private readonly IMediator _mediator;
    public AccountModuleDbContext(DbContextOptions<AccountModuleDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<KnownAccount?> AccountModule { get; set; }
    public DbSet<KnownBusiness?> KnownBusinesses { get; set; }
    public DbSet<KnownBusinessWebsite> KnownBusinessWebsites { get; set; }
    public DbSet<KnownBusinessWebsiteAlias> KnownBusinessWebsiteAliases { get; set; }
    public DbSet<KnownUser> KnownUsers { get; set; }
    public DbSet<KnownAccountSubscription> KnownAccountSubscriptions { get; set; }
    public DbSet<KnownBusinessProfile> KnownBusinessProfiles { get; set; }
    public DbSet<KnownAccountProfile> KnownAccountProfiles { get; set; }
    public DbSet<WebsitePage> WebsitePages { get; set; }
    public DbSet<WebsitePageContent> WebsitePageContents { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

        // alternately this is built-in to EF Core 2.2
        //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        var entries = ChangeTracker.Entries<BaseEntityTracked<Guid>>().Where(E => E.State == EntityState.Added || E.State == EntityState.Modified).ToList();

        foreach (var entityEntry in entries)
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
            }
            else if (entityEntry.State == EntityState.Added)
            {
                /*  if(entityEntry.Property("Id").CurrentValue == Guid.Empty.ToString()) {
                     entityEntry.Property("Id").CurrentValue = Guid.NewGuid();
                 } */
                entityEntry.Property("CreatedOn").CurrentValue = DateTime.UtcNow;
                entityEntry.Property("UpdatedOn").CurrentValue = DateTime.UtcNow;
            }
        }

        int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

        // ignore events if no dispatcher provided
        if (_mediator == null) return result;

        // dispatch events only if save was successful
        var entitiesWithEvents = ChangeTracker.Entries<BaseEntity<System.Guid>>()
            .Select(e => e.Entity)
            .Where(e => e.Events.Any())
            .ToArray();

        foreach (var entity in entitiesWithEvents)
        {
            var events = entity.Events.ToArray();
            entity.Events.Clear();
            foreach (var domainEvent in events)
            {
                await _mediator.Publish(domainEvent, cancellationToken).ConfigureAwait(false);
            }
        }

        return result;
    }

    public override int SaveChanges()
    {
        return SaveChangesAsync().GetAwaiter().GetResult();
    }
}
