using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YesilEvMVC.UI.Migrations
{
    /// <inheritdoc />
    public partial class init1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aktivite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AktiviteAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AktivitePuani = table.Column<int>(type: "int", nullable: true),
                    AktiviteZamani = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aktivite", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "KayitTipi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KayitAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KayitTipi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Uretici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UreticiAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Uretici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrunRisk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RiskAdi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunRisk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UrunRiskRenk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Renk = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunRiskRenk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciSoyadi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PremiumMu = table.Column<bool>(type: "bit", nullable: false),
                    KayitTipiId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUsers_KayitTipi_KayitTipiId",
                        column: x => x.KayitTipiId,
                        principalTable: "KayitTipi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
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
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                name: "KullaniciAktivite",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    AktiviteId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciAktivite", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciAktivite_Aktivite_AktiviteId",
                        column: x => x.AktiviteId,
                        principalTable: "Aktivite",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KullaniciAktivite_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProgramIzin",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kamera = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgramIzin", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgramIzin_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Urun",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BarkodNo = table.Column<int>(type: "int", nullable: true),
                    UrunAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    UreticiId = table.Column<int>(type: "int", nullable: false),
                    RenkId = table.Column<int>(type: "int", nullable: false),
                    UrunIcerik = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urun", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Urun_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urun_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urun_Uretici_UreticiId",
                        column: x => x.UreticiId,
                        principalTable: "Uretici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Urun_UrunRiskRenk_RenkId",
                        column: x => x.RenkId,
                        principalTable: "UrunRiskRenk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciFavori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    KullaniciId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciFavori", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciFavori_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciFavori_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_KullaniciFavori_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrunIcerik",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcerikAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullanimKosul = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunIcerik", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunIcerik_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UrunIcerik_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UrunPaylas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PaylasmaTipi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunPaylas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunPaylas_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "KullaniciKaraListe",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UrunIcerikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciKaraListe", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KullaniciKaraListe_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciKaraListe_UrunIcerik_UrunIcerikId",
                        column: x => x.UrunIcerikId,
                        principalTable: "UrunIcerik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrunIcerikRisk",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcerikId = table.Column<int>(type: "int", nullable: false),
                    UrunRiskId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunIcerikRisk", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunIcerikRisk_UrunIcerik_IcerikId",
                        column: x => x.IcerikId,
                        principalTable: "UrunIcerik",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UrunIcerikRisk_UrunRisk_UrunRiskId",
                        column: x => x.UrunRiskId,
                        principalTable: "UrunRisk",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UrunPaylasKaydi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciId = table.Column<int>(type: "int", nullable: false),
                    UrunId = table.Column<int>(type: "int", nullable: false),
                    PaylasmaId = table.Column<int>(type: "int", nullable: false),
                    PaylasimTarihi = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrunPaylasKaydi", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrunPaylasKaydi_AspNetUsers_KullaniciId",
                        column: x => x.KullaniciId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunPaylasKaydi_UrunPaylas_PaylasmaId",
                        column: x => x.PaylasmaId,
                        principalTable: "UrunPaylas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UrunPaylasKaydi_Urun_UrunId",
                        column: x => x.UrunId,
                        principalTable: "Urun",
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
                name: "IX_AspNetUsers_KayitTipiId",
                table: "AspNetUsers",
                column: "KayitTipiId");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAktivite_AktiviteId",
                table: "KullaniciAktivite",
                column: "AktiviteId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciAktivite_KullaniciId",
                table: "KullaniciAktivite",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFavori_KategoriId",
                table: "KullaniciFavori",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFavori_KullaniciId",
                table: "KullaniciFavori",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciFavori_UrunId",
                table: "KullaniciFavori",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciKaraListe_KullaniciId",
                table: "KullaniciKaraListe",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciKaraListe_UrunIcerikId",
                table: "KullaniciKaraListe",
                column: "UrunIcerikId");

            migrationBuilder.CreateIndex(
                name: "IX_ProgramIzin_KullaniciId",
                table: "ProgramIzin",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KategoriId",
                table: "Urun",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_KullaniciId",
                table: "Urun",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_RenkId",
                table: "Urun",
                column: "RenkId");

            migrationBuilder.CreateIndex(
                name: "IX_Urun_UreticiId",
                table: "Urun",
                column: "UreticiId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunIcerik_KategoriId",
                table: "UrunIcerik",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunIcerik_UrunId",
                table: "UrunIcerik",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunIcerikRisk_IcerikId",
                table: "UrunIcerikRisk",
                column: "IcerikId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunIcerikRisk_UrunRiskId",
                table: "UrunIcerikRisk",
                column: "UrunRiskId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunPaylas_UrunId",
                table: "UrunPaylas",
                column: "UrunId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunPaylasKaydi_KullaniciId",
                table: "UrunPaylasKaydi",
                column: "KullaniciId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunPaylasKaydi_PaylasmaId",
                table: "UrunPaylasKaydi",
                column: "PaylasmaId");

            migrationBuilder.CreateIndex(
                name: "IX_UrunPaylasKaydi_UrunId",
                table: "UrunPaylasKaydi",
                column: "UrunId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "KullaniciAktivite");

            migrationBuilder.DropTable(
                name: "KullaniciFavori");

            migrationBuilder.DropTable(
                name: "KullaniciKaraListe");

            migrationBuilder.DropTable(
                name: "ProgramIzin");

            migrationBuilder.DropTable(
                name: "UrunIcerikRisk");

            migrationBuilder.DropTable(
                name: "UrunPaylasKaydi");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Aktivite");

            migrationBuilder.DropTable(
                name: "UrunIcerik");

            migrationBuilder.DropTable(
                name: "UrunRisk");

            migrationBuilder.DropTable(
                name: "UrunPaylas");

            migrationBuilder.DropTable(
                name: "Urun");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Kategori");

            migrationBuilder.DropTable(
                name: "Uretici");

            migrationBuilder.DropTable(
                name: "UrunRiskRenk");

            migrationBuilder.DropTable(
                name: "KayitTipi");
        }
    }
}
