// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WskInfrastructure.Data;

#nullable disable

namespace WskApplication.Data.Migrations
{
    [DbContext(typeof(WskDbContext))]
    [Migration("20230630041646_init9")]
    partial class init9
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.8");

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.Property<Guid>("AuthorsId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BooksId")
                        .HasColumnType("TEXT");

                    b.HasKey("AuthorsId", "BooksId");

                    b.HasIndex("BooksId");

                    b.ToTable("AuthorBook");
                });

            modelBuilder.Entity("WskCore.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("WskCore.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("LibraryId")
                        .HasColumnType("TEXT");

                    b.Property<int>("PageCount")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("LibraryId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("WskCore.Entities.BookCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BookCategoryId")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookCategoryId");

                    b.HasIndex("BookId");

                    b.ToTable("BookCategories");
                });

            modelBuilder.Entity("WskCore.Entities.BookCopy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("BookId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Condition")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CopySequence")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("BookCopies");
                });

            modelBuilder.Entity("WskCore.Entities.Library", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("UpdatedOn")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Libraries");
                });

            modelBuilder.Entity("AuthorBook", b =>
                {
                    b.HasOne("WskCore.Entities.Author", null)
                        .WithMany()
                        .HasForeignKey("AuthorsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WskCore.Entities.Book", null)
                        .WithMany()
                        .HasForeignKey("BooksId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("WskCore.Entities.Author", b =>
                {
                    b.OwnsOne("WskCore.Entities.NameVO", "Name", b1 =>
                        {
                            b1.Property<Guid>("AuthorId")
                                .HasColumnType("TEXT");

                            b1.HasKey("AuthorId");

                            b1.ToTable("Authors");

                            b1.WithOwner()
                                .HasForeignKey("AuthorId");
                        });

                    b.Navigation("Name")
                        .IsRequired();
                });

            modelBuilder.Entity("WskCore.Entities.Book", b =>
                {
                    b.HasOne("WskCore.Entities.Library", null)
                        .WithMany("Books")
                        .HasForeignKey("LibraryId");

                    b.OwnsOne("WskCore.Entities.IsbnVO", "Isbn", b1 =>
                        {
                            b1.Property<Guid>("BookId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Isbn")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("BookId");

                            b1.HasIndex("Isbn")
                                .IsUnique()
                                .HasDatabaseName("Index_Isbn")
                                .HasAnnotation("SqlServer:Clustered", false);

                            b1.ToTable("Books");

                            b1.WithOwner()
                                .HasForeignKey("BookId");
                        });

                    b.Navigation("Isbn")
                        .IsRequired();
                });

            modelBuilder.Entity("WskCore.Entities.BookCategory", b =>
                {
                    b.HasOne("WskCore.Entities.BookCategory", null)
                        .WithMany("BookCategories")
                        .HasForeignKey("BookCategoryId");

                    b.HasOne("WskCore.Entities.Book", null)
                        .WithMany("BookCategories")
                        .HasForeignKey("BookId");
                });

            modelBuilder.Entity("WskCore.Entities.BookCopy", b =>
                {
                    b.HasOne("WskCore.Entities.Book", "Book")
                        .WithMany("BookCopies")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("WskCore.Entities.Library", b =>
                {
                    b.OwnsOne("WskCore.Entities.DigitalAddressVO", "PrimaryEmail", b1 =>
                        {
                            b1.Property<Guid>("LibraryId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<long>("PhoneNumber")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Type")
                                .HasColumnType("INTEGER");

                            b1.HasKey("LibraryId");

                            b1.ToTable("Libraries");

                            b1.WithOwner()
                                .HasForeignKey("LibraryId");
                        });

                    b.OwnsOne("WskCore.Entities.DigitalAddressVO", "PrimaryPhone", b1 =>
                        {
                            b1.Property<Guid>("LibraryId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<long>("PhoneNumber")
                                .HasColumnType("INTEGER");

                            b1.Property<int>("Type")
                                .HasColumnType("INTEGER");

                            b1.HasKey("LibraryId");

                            b1.ToTable("Libraries");

                            b1.WithOwner()
                                .HasForeignKey("LibraryId");
                        });

                    b.OwnsOne("WskCore.Entities.PhysicalAddressVO", "MailingAddress", b1 =>
                        {
                            b1.Property<Guid>("LibraryId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Country")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("StateProvince")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street1")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street2")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("LibraryId");

                            b1.ToTable("Libraries");

                            b1.WithOwner()
                                .HasForeignKey("LibraryId");
                        });

                    b.Navigation("MailingAddress")
                        .IsRequired();

                    b.Navigation("PrimaryEmail")
                        .IsRequired();

                    b.Navigation("PrimaryPhone")
                        .IsRequired();
                });

            modelBuilder.Entity("WskCore.Entities.Book", b =>
                {
                    b.Navigation("BookCategories");

                    b.Navigation("BookCopies");
                });

            modelBuilder.Entity("WskCore.Entities.BookCategory", b =>
                {
                    b.Navigation("BookCategories");
                });

            modelBuilder.Entity("WskCore.Entities.Library", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
