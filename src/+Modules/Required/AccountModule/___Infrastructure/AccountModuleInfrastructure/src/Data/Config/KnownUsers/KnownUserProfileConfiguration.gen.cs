// ag=yes
namespace AccountModuleCore.Infrastructure.Data.Config;
public partial class KnownUserProfileConfiguration : IEntityTypeConfiguration<KnownUserProfile>
{ 
    public void Configure(EntityTypeBuilder<KnownUserProfile> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        