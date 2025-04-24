using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace YesilEvMVC.UI.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "KullaniciAdi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "KullaniciSoyadi",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "PremiumMu",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KullanimKosul",
                table: "UrunIcerik",
                newName: "Aciklama");

            migrationBuilder.AlterColumn<int>(
                name: "KayitTipiId",
                table: "AspNetUsers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "KayitTipi",
                columns: new[] { "Id", "KayitAdi" },
                values: new object[,]
                {
                    { 1, "Gmail" },
                    { 2, "Hotmail" },
                    { 3, "Yahoo" },
                    { 4, "Outlook" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "KayitTipi",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "KayitTipi",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "KayitTipi",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "KayitTipi",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.RenameColumn(
                name: "Aciklama",
                table: "UrunIcerik",
                newName: "KullanimKosul");

            migrationBuilder.AlterColumn<int>(
                name: "KayitTipiId",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "KullaniciAdi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "KullaniciSoyadi",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "PremiumMu",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
