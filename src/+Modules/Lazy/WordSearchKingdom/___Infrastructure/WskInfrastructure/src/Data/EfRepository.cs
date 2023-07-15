namespace WskInfrastructure.Data;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(WskDbContext dbContext) : base(dbContext)
    {
    }
}
