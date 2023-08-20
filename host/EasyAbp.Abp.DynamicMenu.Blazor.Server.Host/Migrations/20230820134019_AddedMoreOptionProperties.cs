using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.Abp.DynamicMenu.Blazor.Server.Host.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreOptionProperties : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDisabled",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Target",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Icon",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "IsDisabled",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "Target",
                table: "EasyAbpAbpDynamicMenuMenuItems");
        }
    }
}
