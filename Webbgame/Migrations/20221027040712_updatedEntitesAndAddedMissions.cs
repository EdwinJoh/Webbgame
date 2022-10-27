using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Webbgame.Migrations
{
    /// <inheritdoc />
    public partial class updatedEntitesAndAddedMissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Money",
                table: "Characters",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Money",
                table: "Characters");
        }
    }
}
