using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccountModule.Data.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountModule",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    AliasName = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsJokerFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountModule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnownAccountSubscriptions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownAccountSubscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnownBusinesses",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    Industry = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false),
                    StateCode = table.Column<int>(type: "INTEGER", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    ParentBusinessId = table.Column<Guid>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownBusinesses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownBusinesses_KnownBusinesses_ParentBusinessId",
                        column: x => x.ParentBusinessId,
                        principalTable: "KnownBusinesses",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KnownUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    UserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    EmailAddress = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LastAgreedToTOS = table.Column<DateTime>(type: "TEXT", nullable: true),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsJokerFlag = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KnownAccountProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    KnownAccountId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownAccountProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownAccountProfiles_AccountModule_KnownAccountId",
                        column: x => x.KnownAccountId,
                        principalTable: "AccountModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownBusinessProfiles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    KnownBusinessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownBusinessProfiles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownBusinessProfiles_KnownBusinesses_KnownBusinessId",
                        column: x => x.KnownBusinessId,
                        principalTable: "KnownBusinesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownBusinessWebsites",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", maxLength: 1024, nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    KnownBusinessId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownBusinessWebsites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownBusinessWebsites_KnownBusinesses_KnownBusinessId",
                        column: x => x.KnownBusinessId,
                        principalTable: "KnownBusinesses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownBusinessWebsiteAliases",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    KnownBusinessWebsiteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    Url = table.Column<string>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    IsActive = table.Column<bool>(type: "INTEGER", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownBusinessWebsiteAliases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownBusinessWebsiteAliases_KnownBusinessWebsites_KnownBusinessWebsiteId",
                        column: x => x.KnownBusinessWebsiteId,
                        principalTable: "KnownBusinessWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownBusinessWebsiteProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    DefaultUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    LandingUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: true),
                    RootFolder = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LogoImage = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Surface = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Black = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Background = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    BackgroundGrey = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawerBackground = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    AppbarBackground = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ActionDefault = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ActionDisabled = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ActionDisabledBackground = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Divider = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DividerLight = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TableLines = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LinesDefault = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    LinesInputs = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Primary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Secondary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Info = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Success = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Warning = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Error = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    AppbarText = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TextPrimary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TextSecondary = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    TextDisabled = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawerText = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawerIcon = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawerWidthLeft = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DrawerWidthRight = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DefaultFontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DefaultFontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    DefaultFontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    DefaultLineHeight = table.Column<double>(type: "REAL", nullable: true),
                    DefaultLetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H1FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H1FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H1FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H1LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H1LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H2FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H2FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H2FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H2LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H2LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H3FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H3FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H3FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H3LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H3LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H4FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H4FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H4FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H4LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H4LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H5FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H5FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H5FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H5LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H5LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H6FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H6FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    H6FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    H6LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    H6LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body1FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body1FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body1FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    Body1LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    Body1LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body2FontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body2FontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    Body2FontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    Body2LineHeight = table.Column<double>(type: "REAL", nullable: true),
                    Body2LetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ButtonFontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ButtonFontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    ButtonFontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    ButtonLineHeight = table.Column<double>(type: "REAL", nullable: true),
                    ButtonLetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CaptionFontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CaptionFontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    CaptionFontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    CaptionLineHeight = table.Column<double>(type: "REAL", nullable: true),
                    CaptionLetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    OverlineFontFamily = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    OverlineFontSize = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    OverlineFontWeight = table.Column<int>(type: "INTEGER", nullable: true),
                    OverlineLineHeight = table.Column<double>(type: "REAL", nullable: true),
                    OverlineLetterSpacing = table.Column<string>(type: "TEXT", maxLength: 100, nullable: true),
                    KnownBusinessWebsiteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownBusinessWebsiteProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownBusinessWebsiteProfile_KnownBusinessWebsites_KnownBusinessWebsiteId",
                        column: x => x.KnownBusinessWebsiteId,
                        principalTable: "KnownBusinessWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KnownUserProfile",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 101, nullable: false),
                    KnownUserId = table.Column<Guid>(type: "TEXT", nullable: false),
                    KnownBusinessWebsiteId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnownUserProfile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnownUserProfile_KnownBusinessWebsites_KnownBusinessWebsiteId",
                        column: x => x.KnownBusinessWebsiteId,
                        principalTable: "KnownBusinessWebsites",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KnownUserProfile_KnownUsers_KnownUserId",
                        column: x => x.KnownUserId,
                        principalTable: "KnownUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsitePages",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WebsiteParentPageId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WebsitePageContent = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    KnownBusinessWebsiteId = table.Column<Guid>(type: "TEXT", nullable: true),
                    WebPageUrl = table.Column<string>(type: "TEXT", maxLength: 1000, nullable: false),
                    IsVirtual = table.Column<bool>(type: "INTEGER", nullable: false),
                    IsInNavigation = table.Column<bool>(type: "INTEGER", nullable: false),
                    PageTitle = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NavText = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    NavIcon = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsitePages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsitePages_KnownBusinessWebsites_KnownBusinessWebsiteId",
                        column: x => x.KnownBusinessWebsiteId,
                        principalTable: "KnownBusinessWebsites",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_WebsitePages_WebsitePages_WebsiteParentPageId",
                        column: x => x.WebsiteParentPageId,
                        principalTable: "WebsitePages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WebsitePageContents",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    WebsitePageId = table.Column<Guid>(type: "TEXT", nullable: false),
                    HtmlContent = table.Column<string>(type: "TEXT", maxLength: 65535, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsitePageContents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsitePageContents_WebsitePages_WebsitePageId",
                        column: x => x.WebsitePageId,
                        principalTable: "WebsitePages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_KnownAccountProfiles_KnownAccountId",
                table: "KnownAccountProfiles",
                column: "KnownAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownBusinesses_ParentBusinessId",
                table: "KnownBusinesses",
                column: "ParentBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownBusinessProfiles_KnownBusinessId",
                table: "KnownBusinessProfiles",
                column: "KnownBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownBusinessWebsiteAliases_KnownBusinessWebsiteId",
                table: "KnownBusinessWebsiteAliases",
                column: "KnownBusinessWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownBusinessWebsiteProfile_KnownBusinessWebsiteId",
                table: "KnownBusinessWebsiteProfile",
                column: "KnownBusinessWebsiteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KnownBusinessWebsites_KnownBusinessId",
                table: "KnownBusinessWebsites",
                column: "KnownBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownUserProfile_KnownBusinessWebsiteId",
                table: "KnownUserProfile",
                column: "KnownBusinessWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_KnownUserProfile_KnownUserId",
                table: "KnownUserProfile",
                column: "KnownUserId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsitePageContents_WebsitePageId",
                table: "WebsitePageContents",
                column: "WebsitePageId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsitePages_KnownBusinessWebsiteId",
                table: "WebsitePages",
                column: "KnownBusinessWebsiteId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsitePages_WebsiteParentPageId",
                table: "WebsitePages",
                column: "WebsiteParentPageId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "KnownAccountProfiles");

            migrationBuilder.DropTable(
                name: "KnownAccountSubscriptions");

            migrationBuilder.DropTable(
                name: "KnownBusinessProfiles");

            migrationBuilder.DropTable(
                name: "KnownBusinessWebsiteAliases");

            migrationBuilder.DropTable(
                name: "KnownBusinessWebsiteProfile");

            migrationBuilder.DropTable(
                name: "KnownUserProfile");

            migrationBuilder.DropTable(
                name: "WebsitePageContents");

            migrationBuilder.DropTable(
                name: "AccountModule");

            migrationBuilder.DropTable(
                name: "KnownUsers");

            migrationBuilder.DropTable(
                name: "WebsitePages");

            migrationBuilder.DropTable(
                name: "KnownBusinessWebsites");

            migrationBuilder.DropTable(
                name: "KnownBusinesses");
        }
    }
}
