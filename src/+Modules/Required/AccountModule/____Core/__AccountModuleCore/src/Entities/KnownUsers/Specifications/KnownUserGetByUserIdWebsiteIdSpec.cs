using System.Security.Cryptography;
namespace AccountModuleCore.Entities;
public class KnownUserGetByUserIdWebsiteIdSpec : Specification<KnownUser>, ISingleResultSpecification<KnownUser>
{
    public KnownUserGetByUserIdWebsiteIdSpec(Guid knownUserId, Guid knownBusinessWebsiteId)
    {
        Query
            .Include(rs => rs.KnownUserProfiles.Where(rs => rs.KnownBusinessWebsiteId == knownBusinessWebsiteId))
            .Where(rs => rs.UserId == knownUserId)
            
            ;
    }
}
