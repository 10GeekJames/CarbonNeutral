// ag=yes
namespace WskCore.Infrastructure.Data.Config;
public partial class RowCellConfiguration : IEntityTypeConfiguration<RowCell>
{ 
    public void Configure(EntityTypeBuilder<RowCell> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        