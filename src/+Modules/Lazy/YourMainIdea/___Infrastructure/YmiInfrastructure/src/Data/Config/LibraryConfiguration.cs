namespace YmiInfrastructure.Data.Config;
public class LibraryConfiguration : IEntityTypeConfiguration<Library>
{
    public void Configure(EntityTypeBuilder<Library> builder)
    {
        builder.OwnsOne(rs => rs.MailingAddress, rs =>
            {
                rs.WithOwner();
            });
        builder.OwnsOne(rs => rs.PrimaryPhone, rs =>
            {
                rs.WithOwner();
            });
        builder.OwnsOne(rs => rs.PrimaryEmail, rs =>
            {
                rs.WithOwner();
            });
    }
}
