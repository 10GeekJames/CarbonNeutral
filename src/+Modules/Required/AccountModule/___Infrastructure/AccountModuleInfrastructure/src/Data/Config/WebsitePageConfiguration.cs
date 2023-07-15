namespace AccountModule.WebsitePages.Infrastructure.Data.Config;
public partial class WebsitePageConfiguration : IEntityTypeConfiguration<WebsitePage>
{
    public void Configure(EntityTypeBuilder<WebsitePage> builder)
    {
        builder
           .HasMany(rs => rs.WebsiteChildPages)
           .WithOne(rs => rs.WebsiteParentPage)
           .HasForeignKey(rs => rs.WebsiteParentPageId)
           .OnDelete(DeleteBehavior.NoAction)
           ;
    }
}
