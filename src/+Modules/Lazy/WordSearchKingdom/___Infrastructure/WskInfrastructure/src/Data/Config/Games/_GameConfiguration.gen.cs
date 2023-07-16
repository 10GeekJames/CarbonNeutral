// ag=no
namespace WskCore.Infrastructure.Data.Config;
public partial class GameConfiguration : IEntityTypeConfiguration<Game>
{ 
    public void Configure(EntityTypeBuilder<Game> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        builder.HasMany(g => g.GameTags)
            .WithMany(rs => rs.Games);
        builder.HasMany(g => g.GameCategories)
            .WithMany(rs => rs.Games);
    }
} 
        