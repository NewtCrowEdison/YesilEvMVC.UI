using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YesilEvMVC.UI.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ArkaYuzResmiYolu",
                table: "Urun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OnYuzResmiYolu",
                table: "Urun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ArkaYuzResmiYolu",
                table: "Urun");

            migrationBuilder.DropColumn(
                name: "OnYuzResmiYolu",
                table: "Urun");
        }
    }
}
