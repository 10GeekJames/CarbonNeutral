namespace YmiInfrastructure.Data;
public class YmiDbContext : DbContext
{
    private readonly IMediator _mediator;
    public YmiDbContext(DbContextOptions<YmiDbContext> options, IMediator mediator)
        : base(options)
    {
        _mediator = mediator;
    }

    public DbSet<Library> Libraries { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<BookCopy> BookCopies { get; set; }
    public DbSet<Author> Authors { get; set; }
    
    // Shared
    public DbSet<BookCategory> BookCategories { get; set; } 

    // Value Objects
  /*   public DbSet<DigitalAddressVO> DigitalAddressVOs {get;set;}
    public DbSet<NameVO> NameVOs {get;set;}
    public DbSet<PhysicalAddressVO> DigitalAddressePhysicalAddressVOs {get;set;} */


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