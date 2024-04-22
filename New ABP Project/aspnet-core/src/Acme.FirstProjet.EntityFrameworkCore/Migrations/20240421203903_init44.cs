using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Acme.FirstProjet.Migrations
{
    /// <inheritdoc />
    public partial class init44 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ConcurrencyStamp",
                table: "AppPatientAddresses",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AppPatientAddresses",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreatorId",
                table: "AppPatientAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "DeleterId",
                table: "AppPatientAddresses",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AppPatientAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ExtraProperties",
                table: "AppPatientAddresses",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AppPatientAddresses",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AppPatientAddresses",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LastModifierId",
                table: "AppPatientAddresses",
                type: "uniqueidentifier",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConcurrencyStamp",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "DeleterId",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "ExtraProperties",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AppPatientAddresses");

            migrationBuilder.DropColumn(
                name: "LastModifierId",
                table: "AppPatientAddresses");
        }
    }
}
