using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbgame.Migrations
{
    /// <inheritdoc />
    public partial class moddedweaponForuser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Weapons_Characters_CharactersId",
                table: "Weapons");

            migrationBuilder.DropIndex(
                name: "IX_Weapons_CharactersId",
                table: "Weapons");

            migrationBuilder.DropColumn(
                name: "CharactersId",
                table: "Weapons");

            migrationBuilder.AddColumn<Guid>(
                name: "WeaponsId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Characters_WeaponsId",
                table: "Characters",
                column: "WeaponsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_Characters_WeaponsId",
                table: "Characters");

            migrationBuilder.DropColumn(
                name: "WeaponsId",
                table: "Characters");

            migrationBuilder.AddColumn<Guid>(
                name: "CharactersId",
                table: "Weapons",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharactersId",
                table: "Weapons",
                column: "CharactersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Weapons_Characters_CharactersId",
                table: "Weapons",
                column: "CharactersId",
                principalTable: "Characters",
                principalColumn: "Id");
        }
    }
}
