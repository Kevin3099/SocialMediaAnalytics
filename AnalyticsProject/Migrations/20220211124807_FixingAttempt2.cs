using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class FixingAttempt2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryInformationVM");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryInformations_EventId",
                table: "SummaryInformations",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_SummaryInformations_Events_EventId",
                table: "SummaryInformations",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "EventId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SummaryInformations_Events_EventId",
                table: "SummaryInformations");

            migrationBuilder.DropIndex(
                name: "IX_SummaryInformations_EventId",
                table: "SummaryInformations");

            migrationBuilder.CreateTable(
                name: "SummaryInformationVM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountOfPosts = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    EventsId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    averageComments = table.Column<int>(type: "int", nullable: false),
                    averageLikes = table.Column<int>(type: "int", nullable: false),
                    averageRetweets = table.Column<int>(type: "int", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    followerIncrease = table.Column<int>(type: "int", nullable: false),
                    totalComments = table.Column<int>(type: "int", nullable: false),
                    totalFollowers = table.Column<int>(type: "int", nullable: false),
                    totalLikes = table.Column<int>(type: "int", nullable: false),
                    totalRetweets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryInformationVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryInformationVM_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "EventId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SummaryInformationVM_EventId",
                table: "SummaryInformationVM",
                column: "EventId");
        }
    }
}
