using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.Abp.DynamicMenu.Migrations
{
    /// <inheritdoc />
    public partial class AddedInAdministrationProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "InAdministration",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InAdministration",
                table: "EasyAbpAbpDynamicMenuMenuItems");
        }
    }
}
