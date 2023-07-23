// ag=yes
namespace AccountModuleCore.Infrastructure.Data.Config;
public partial class KnownBusinessProfileConfiguration : IEntityTypeConfiguration<KnownBusinessProfile>
{ 
    public void Configure(EntityTypeBuilder<KnownBusinessProfile> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        