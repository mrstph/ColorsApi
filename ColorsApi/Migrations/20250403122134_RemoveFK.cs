using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ColorsApi.Migrations
{
    /// <inheritdoc />
    public partial class RemoveFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Palettes_ColorPaletteEntityId",
                table: "Colors");

            migrationBuilder.DropColumn(
                name: "PaletteId",
                table: "Colors");

            migrationBuilder.AlterColumn<int>(
                name: "ColorPaletteEntityId",
                table: "Colors",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Palettes_ColorPaletteEntityId",
                table: "Colors",
                column: "ColorPaletteEntityId",
                principalTable: "Palettes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colors_Palettes_ColorPaletteEntityId",
                table: "Colors");

            migrationBuilder.AlterColumn<int>(
                name: "ColorPaletteEntityId",
                table: "Colors",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "PaletteId",
                table: "Colors",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Colors_Palettes_ColorPaletteEntityId",
                table: "Colors",
                column: "ColorPaletteEntityId",
                principalTable: "Palettes",
                principalColumn: "Id");
        }
    }
}
