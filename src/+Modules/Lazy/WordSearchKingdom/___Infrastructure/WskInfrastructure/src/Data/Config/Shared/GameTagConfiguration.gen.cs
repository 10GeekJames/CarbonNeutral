// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class GameTagConfiguration : IEntityTypeConfiguration<GameTag>
{ 
    public void Configure(EntityTypeBuilder<GameTag> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        