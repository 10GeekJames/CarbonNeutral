// ag=yes
namespace AccountModuleCore.Infrastructure.Data.Config;
public partial class KnownAccountProfileConfiguration : IEntityTypeConfiguration<KnownAccountProfile>
{ 
    public void Configure(EntityTypeBuilder<KnownAccountProfile> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        