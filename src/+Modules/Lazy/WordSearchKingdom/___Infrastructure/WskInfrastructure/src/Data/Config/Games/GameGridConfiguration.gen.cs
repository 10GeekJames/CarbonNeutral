// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class GameGridConfiguration : IEntityTypeConfiguration<GameGrid>
{ 
    public void Configure(EntityTypeBuilder<GameGrid> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        