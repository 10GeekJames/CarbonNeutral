namespace AccountModuleCore.Entities;
public class KnownUserGetByUserIdSpec : Specification<KnownUser>, ISingleResultSpecification<KnownUser>
{
    public KnownUserGetByUserIdSpec(Guid userId)
    {
        Query
            .Where(s => s.UserId == userId)
            //.AsNoTracking()
            ;
    }
}
