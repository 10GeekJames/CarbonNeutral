// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class GameConfiguration : IEntityTypeConfiguration<Game>
{ 
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        