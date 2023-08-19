namespace LiveRoomInfrastructure.Data;
public class LiveRoomDbContext : DbContext
{
    private readonly IMediator _mediator;
    public LiveRoomDbContext(DbContextOptions<LiveRoomDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<LiveRoomSession> LiveRoomSessions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.BuildIndexesFromAnnotations();
        modelBuilder.BuildIndexesFromAnnotationsForSqlServer();
        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

        //this.ChangeTracker.LazyLoadingEnabled = true;
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in ChangeTracker
            .Entries()
            .Where(E => (E.State == EntityState.Added
                || E.State == EntityState.Modified)
                && E.GetType().Name.EndsWith("VO") )
            .ToList())
        {
            if (entityEntry.State == EntityState.Modified)
            {
                entityEntry.Property("UpdatedOn").CurrentValue = DateTime.Now;
            }
            else if (entityEntry.State == EntityState.Added)
            {
                entityEntry.Property("CreatedOn").CurrentValue = DateTime.Now;
                entityEntry.Property("UpdatedOn").CurrentValue = DateTime.Now;
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