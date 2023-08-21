// ag=yes
namespace AccountModuleCore.Infrastructure.Data.Config;
public partial class KnownAccountSubscriptionConfiguration : IEntityTypeConfiguration<KnownAccountSubscription>
{ 
    public void Configure(EntityTypeBuilder<KnownAccountSubscription> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        