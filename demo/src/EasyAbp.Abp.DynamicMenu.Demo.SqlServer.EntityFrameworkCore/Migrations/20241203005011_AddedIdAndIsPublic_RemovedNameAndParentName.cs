using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyAbp.Abp.DynamicMenu.Demo.SqlServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedIdAndIsPublic_RemovedNameAndParentName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyAbpAbpDynamicMenuMenuItems_EasyAbpAbpDynamicMenuMenuItems_ParentName",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.RenameColumn(
                name: "ParentName",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "ParentId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicMenuMenuItems_ParentName",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "IX_EasyAbpAbpDynamicMenuMenuItems_ParentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EasyAbpAbpDynamicMenuMenuItems_EasyAbpAbpDynamicMenuMenuItems_ParentId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                column: "ParentId",
                principalTable: "EasyAbpAbpDynamicMenuMenuItems",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EasyAbpAbpDynamicMenuMenuItems_EasyAbpAbpDynamicMenuMenuItems_ParentId",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "EasyAbpAbpDynamicMenuMenuItems");

            migrationBuilder.RenameColumn(
                name: "ParentId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "ParentName");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_EasyAbpAbpDynamicMenuMenuItems_ParentId",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                newName: "IX_EasyAbpAbpDynamicMenuMenuItems_ParentName");

            migrationBuilder.AddForeignKey(
                name: "FK_EasyAbpAbpDynamicMenuMenuItems_EasyAbpAbpDynamicMenuMenuItems_ParentName",
                table: "EasyAbpAbpDynamicMenuMenuItems",
                column: "ParentName",
                principalTable: "EasyAbpAbpDynamicMenuMenuItems",
                principalColumn: "Name");
        }
    }
}
