using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class EventStatistics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_FilterVM_FilterId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "FilterVM");

            migrationBuilder.DropIndex(
                name: "IX_Events_FilterId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FilterId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Events",
                newName: "EventId");

            migrationBuilder.AddColumn<Guid>(
                name: "EventsId",
                table: "SummaryInformations",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateFrom",
                table: "Events",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTo",
                table: "Events",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventsId",
                table: "SummaryInformations");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "EventId",
                table: "Events",
                newName: "Id");

            migrationBuilder.AddColumn<Guid>(
                name: "FilterId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "FilterVM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilterVM", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FilterId",
                table: "Events",
                column: "FilterId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FilterVM_FilterId",
                table: "Events",
                column: "FilterId",
                principalTable: "FilterVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
