// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class GameGridInstanceConfiguration : IEntityTypeConfiguration<GameGridInstance>
{ 
    public void Configure(EntityTypeBuilder<GameGridInstance> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        