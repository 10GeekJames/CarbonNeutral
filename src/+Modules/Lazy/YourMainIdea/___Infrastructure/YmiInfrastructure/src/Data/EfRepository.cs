namespace YmiInfrastructure.Data;
public class EfRepository<T> : RepositoryBase<T>, IReadRepository<T>, IRepository<T> where T : class, IAggregateRoot
{
    public EfRepository(YmiDbContext dbContext) : base(dbContext)
    {
    }
}
