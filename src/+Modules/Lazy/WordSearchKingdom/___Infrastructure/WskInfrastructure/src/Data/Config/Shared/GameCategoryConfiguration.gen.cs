// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class GameCategoryConfiguration : IEntityTypeConfiguration<GameCategory>
{ 
    public void Configure(EntityTypeBuilder<GameCategory> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        