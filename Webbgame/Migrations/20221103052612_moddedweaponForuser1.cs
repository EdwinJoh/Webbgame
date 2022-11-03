﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbgame.Migrations
{
    /// <inheritdoc />
    public partial class moddedweaponForuser1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeaponsId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters");

            migrationBuilder.AlterColumn<Guid>(
                name: "WeaponsId",
                table: "Characters",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Characters_Weapons_WeaponsId",
                table: "Characters",
                column: "WeaponsId",
                principalTable: "Weapons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
