// ag=yes
namespace LiveRoomCore.Infrastructure.Data.Config;
public partial class LiveRoomSessionConfiguration : IEntityTypeConfiguration<LiveRoomSession>
{ 
    public void Configure(EntityTypeBuilder<LiveRoomSession> builder)
    {
        /* builder.Property(p => p.Name)
            .HasMaxLength(100)
            .IsRequired(); */
        
    }
} 
        