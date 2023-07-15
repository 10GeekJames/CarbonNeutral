// ag=yes
namespace AccountModuleCore.Infrastructure.Data.Config;
public partial class KnownBusinessWebsiteConfiguration : IEntityTypeConfiguration<KnownBusinessWebsite>
{ 
    public void Configure(EntityTypeBuilder<KnownBusinessWebsite> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        