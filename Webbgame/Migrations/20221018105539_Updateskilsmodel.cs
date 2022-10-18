using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbgame.Migrations
{
    /// <inheritdoc />
    public partial class Updateskilsmodel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Characters_CharactersId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_CharactersId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CharactersId",
                table: "Skills");

            migrationBuilder.AddColumn<int>(
                name: "SkillsId",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Characters_SkillsId",
                table: "Characters",
                column: "SkillsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Skills_SkillsId",
                table: "Characters",
                column: "SkillsId",
                principalTable: "Skills",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Skills_SkillsId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_SkillsId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "SkillsId",
                table: "Characters");

            migrationBuilder.AddColumn<int>(
                name: "CharactersId",
                table: "Skills",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_CharactersId",
                table: "Skills",
                column: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Characters_CharactersId",
                table: "Skills",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
