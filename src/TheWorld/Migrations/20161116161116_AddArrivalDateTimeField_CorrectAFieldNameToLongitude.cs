using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorld.Migrations
{
    public partial class AddArrivalDateTimeField_CorrectAFieldNameToLongitude : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logitute",
                table: "Stops");

            migrationBuilder.AddColumn<DateTime>(
                name: "Arrival",
                table: "Stops",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Stops",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Arrival",
                table: "Stops");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Stops");

            migrationBuilder.AddColumn<double>(
                name: "Logitute",
                table: "Stops",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
