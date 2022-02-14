using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class FixingDatabaseBug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EventsId",
                table: "SummaryInformations",
                newName: "EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "EventsId",
                table: "SummaryInformationVM",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "SummaryInformationVM");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "SummaryInformations",
                newName: "EventsId");
        }
    }
}
