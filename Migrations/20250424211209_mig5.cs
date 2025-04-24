using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace YesilEvMVC.UI.Migrations
{
    /// <inheritdoc />
    public partial class mig5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UrunIcerik",
                table: "Urun");

            migrationBuilder.AddColumn<int>(
                name: "UrunId1",
                table: "UrunIcerik",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UrunIcerik_UrunId1",
                table: "UrunIcerik",
                column: "UrunId1");

            migrationBuilder.AddForeignKey(
                name: "FK_UrunIcerik_Urun_UrunId1",
                table: "UrunIcerik",
                column: "UrunId1",
                principalTable: "Urun",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UrunIcerik_Urun_UrunId1",
                table: "UrunIcerik");

            migrationBuilder.DropIndex(
                name: "IX_UrunIcerik_UrunId1",
                table: "UrunIcerik");

            migrationBuilder.DropColumn(
                name: "UrunId1",
                table: "UrunIcerik");

            migrationBuilder.AddColumn<string>(
                name: "UrunIcerik",
                table: "Urun",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
