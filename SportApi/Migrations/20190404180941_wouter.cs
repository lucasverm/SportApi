using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SportApi.Migrations
{
    public partial class wouter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Afbeeldingen",
                columns: table => new
                {
                    Adres = table.Column<string>(nullable: true),
                    LesmateriaalId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Afbeeldingen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lesmaterialen",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Graad = table.Column<int>(nullable: false),
                    Naam = table.Column<string>(nullable: true),
                    Categorie = table.Column<string>(nullable: true),
                    OefeningUitlegTekst = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lesmaterialen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Videos",
                columns: table => new
                {
                    Adres = table.Column<string>(nullable: true),
                    LesmateriaalId = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Videos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Commentaren",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Tekst = table.Column<string>(nullable: true),
                    LidId = table.Column<int>(nullable: false),
                    Datum = table.Column<DateTime>(nullable: false),
                    TijdStip = table.Column<TimeSpan>(nullable: false),
                    Lidnaam = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Commentaren", x => new { x.Datum, x.TijdStip });
                    table.ForeignKey(
                        name: "FK_Commentaren_Lesmaterialen_Id",
                        column: x => x.Id,
                        principalTable: "Lesmaterialen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GebruikerSessie",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    SessieId = table.Column<int>(nullable: true),
                    GebruikerId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GebruikerSessie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LesLid",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LesId = table.Column<int>(nullable: true),
                    LidId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LesLid", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Lessen",
                columns: table => new
                {
                    Duur = table.Column<TimeSpan>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LesgeverId = table.Column<int>(nullable: true),
                    StartUur = table.Column<TimeSpan>(nullable: false),
                    Weekdag = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lessen", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Raadplegingen",
                columns: table => new
                {
                    Datum = table.Column<DateTime>(nullable: false),
                    LesmateriaalId = table.Column<int>(nullable: true),
                    LidId = table.Column<int>(nullable: false),
                    TijdStip = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Raadplegingen", x => new { x.Datum, x.TijdStip });
                    table.ForeignKey(
                        name: "FK_Raadplegingen_Lesmaterialen_LesmateriaalId",
                        column: x => x.LesmateriaalId,
                        principalTable: "Lesmaterialen",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sessies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Datum = table.Column<DateTime>(nullable: false),
                    Duur = table.Column<TimeSpan>(nullable: false),
                    LesgeverId = table.Column<int>(nullable: true),
                    StartUur = table.Column<TimeSpan>(nullable: false),
                    Weekdag = table.Column<int>(nullable: false),
                    Bezig = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sessies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gebruikers",
                columns: table => new
                {
                    Email = table.Column<string>(nullable: true),
                    Geslacht = table.Column<string>(nullable: true),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Naam = table.Column<string>(nullable: true),
                    Telefoonnummer = table.Column<string>(nullable: true),
                    Voornaam = table.Column<string>(nullable: true),
                    Geboortedatum = table.Column<DateTime>(nullable: false),
                    Straatnaam = table.Column<string>(nullable: true),
                    Huisnummer = table.Column<string>(nullable: true),
                    Postcode = table.Column<string>(nullable: true),
                    Stad = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    InschrijvingsDatum = table.Column<DateTime>(nullable: true),
                    Nationaleit = table.Column<string>(nullable: true),
                    EmailOuders = table.Column<string>(nullable: true),
                    Rijksregisternummer = table.Column<string>(nullable: true),
                    GeborenTe = table.Column<string>(nullable: true),
                    AkkoordMetHuishoudelijkRegelement = table.Column<bool>(nullable: true),
                    ToestemmingAudioVisueelMateriaal = table.Column<bool>(nullable: true),
                    WenstInfoTeKrijgenOverClubAangelegenheden = table.Column<bool>(nullable: true),
                    WenstInfoTeKrijgenOverFederaleAangelegenhedenEnPromoties = table.Column<bool>(nullable: true),
                    Graad = table.Column<int>(nullable: true),
                    SessieId = table.Column<int>(nullable: true),
                    NietLid_Graad = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gebruikers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gebruikers_Sessies_SessieId",
                        column: x => x.SessieId,
                        principalTable: "Sessies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaren_Id",
                table: "Commentaren",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Commentaren_LidId",
                table: "Commentaren",
                column: "LidId");

            migrationBuilder.CreateIndex(
                name: "IX_Gebruikers_SessieId",
                table: "Gebruikers",
                column: "SessieId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerSessie_GebruikerId",
                table: "GebruikerSessie",
                column: "GebruikerId");

            migrationBuilder.CreateIndex(
                name: "IX_GebruikerSessie_SessieId",
                table: "GebruikerSessie",
                column: "SessieId");

            migrationBuilder.CreateIndex(
                name: "IX_LesLid_LesId",
                table: "LesLid",
                column: "LesId");

            migrationBuilder.CreateIndex(
                name: "IX_LesLid_LidId",
                table: "LesLid",
                column: "LidId");

            migrationBuilder.CreateIndex(
                name: "IX_Lessen_LesgeverId",
                table: "Lessen",
                column: "LesgeverId");

            migrationBuilder.CreateIndex(
                name: "IX_Raadplegingen_LesmateriaalId",
                table: "Raadplegingen",
                column: "LesmateriaalId");

            migrationBuilder.CreateIndex(
                name: "IX_Raadplegingen_LidId",
                table: "Raadplegingen",
                column: "LidId");

            migrationBuilder.CreateIndex(
                name: "IX_Sessies_LesgeverId",
                table: "Sessies",
                column: "LesgeverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Commentaren_Gebruikers_LidId",
                table: "Commentaren",
                column: "LidId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerSessie_Gebruikers_GebruikerId",
                table: "GebruikerSessie",
                column: "GebruikerId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GebruikerSessie_Sessies_SessieId",
                table: "GebruikerSessie",
                column: "SessieId",
                principalTable: "Sessies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LesLid_Gebruikers_LidId",
                table: "LesLid",
                column: "LidId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LesLid_Lessen_LesId",
                table: "LesLid",
                column: "LesId",
                principalTable: "Lessen",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Lessen_Gebruikers_LesgeverId",
                table: "Lessen",
                column: "LesgeverId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Raadplegingen_Gebruikers_LidId",
                table: "Raadplegingen",
                column: "LidId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sessies_Gebruikers_LesgeverId",
                table: "Sessies",
                column: "LesgeverId",
                principalTable: "Gebruikers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessies_Gebruikers_LesgeverId",
                table: "Sessies");

            migrationBuilder.DropTable(
                name: "Afbeeldingen");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Commentaren");

            migrationBuilder.DropTable(
                name: "GebruikerSessie");

            migrationBuilder.DropTable(
                name: "LesLid");

            migrationBuilder.DropTable(
                name: "Raadplegingen");

            migrationBuilder.DropTable(
                name: "Videos");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Lessen");

            migrationBuilder.DropTable(
                name: "Lesmaterialen");

            migrationBuilder.DropTable(
                name: "Gebruikers");

            migrationBuilder.DropTable(
                name: "Sessies");
        }
    }
}
