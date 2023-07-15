// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class HiddenWordConfiguration : IEntityTypeConfiguration<HiddenWord>
{ 
    public void Configure(EntityTypeBuilder<HiddenWord> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        