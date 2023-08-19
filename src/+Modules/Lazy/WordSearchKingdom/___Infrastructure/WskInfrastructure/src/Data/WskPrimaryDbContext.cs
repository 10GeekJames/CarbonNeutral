namespace WskInfrastructure.Data;
public class WskDbContext : DbContext
{
    private readonly IMediator _mediator;
    public WskDbContext(DbContextOptions<WskDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
        this.ChangeTracker.LazyLoadingEnabled = false;
    }

    public DbSet<Game> Games { get; set; }
    public DbSet<GameGrid> GameGrids { get; set; }
    public DbSet<GameGridInstance> GameGridInstances { get; set; }
    public DbSet<HiddenWord> HiddenWords { get; set; }
    public DbSet<RowCell> RowCells { get; set; }

    public DbSet<GameCategory> GameCategories { get; set; }
    public DbSet<GameTag> GameTags { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        //modelBuilder.BuildIndexesFromAnnotations();
        modelBuilder.BuildIndexesFromAnnotationsForSqlServer();
        modelBuilder.ApplyAllConfigurationsFromCurrentAssembly();

        //this.ChangeTracker.LazyLoadingEnabled = true;
        // Configure each entity type

        //AddStronglyTypedIdConversions(modelBuilder);
    }
    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
    {
        foreach (var entityEntry in ChangeTracker
            .Entries()
            .Where(E => (E.State == EntityState.Added
                || E.State == EntityState.Modified)
                && E.GetType().Name.EndsWith("VO"))
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

    /* private static void AddStronglyTypedIdConversions(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            foreach (var property in entityType.GetProperties())
            {
                if (StronglyTypedIdHelper.IsStronglyTypedId(property.ClrType, out var valueType))
                {
                    var converter = StronglyTypedIdConverters.GetOrAdd(
                        property.ClrType,
                        _ => CreateStronglyTypedIdConverter(property.ClrType, valueType));
                    property.SetValueConverter(converter);
                }
            }
        }
    }

    private static readonly ConcurrentDictionary<Type, ValueConverter> StronglyTypedIdConverters = new();

    private static ValueConverter CreateStronglyTypedIdConverter(
        Type stronglyTypedIdType,
        Type valueType)
    {
        // id => id.Value
        var toProviderFuncType = typeof(Func<,>)
            .MakeGenericType(stronglyTypedIdType, valueType);
        var stronglyTypedIdParam = Expression.Parameter(stronglyTypedIdType, "id");
        var toProviderExpression = Expression.Lambda(
            toProviderFuncType,
            Expression.Property(stronglyTypedIdParam, "Value"),
            stronglyTypedIdParam);

        // value => new ProductId(value)
        var fromProviderFuncType = typeof(Func<,>)
            .MakeGenericType(valueType, stronglyTypedIdType);
        var valueParam = Expression.Parameter(valueType, "value");
        var ctor = stronglyTypedIdType.GetConstructor(new[] { valueType });
        var fromProviderExpression = Expression.Lambda(
            fromProviderFuncType,
            Expression.New(ctor, valueParam),
            valueParam);

        var converterType = typeof(ValueConverter<,>)
            .MakeGenericType(stronglyTypedIdType, valueType);

        return (ValueConverter)Activator.CreateInstance(
            converterType,
            toProviderExpression,
            fromProviderExpression,
            null);
    } */
}