using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class AddingEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_FacebookSummarys_FacebookSummarysId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_LinkedInSummarys_LinkedInSummarysId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_TwitterSummarys_TwitterSummarysId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_FacebookSummarysId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_Events_LinkedInSummarysId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "FacebookSummarysId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "LinkedInSummarysId",
                table: "Events");

            migrationBuilder.RenameColumn(
                name: "TwitterSummarysId",
                table: "Events",
                newName: "FilterId");

            migrationBuilder.RenameColumn(
                name: "SearchedTerm",
                table: "Events",
                newName: "Hashtag");

            migrationBuilder.RenameIndex(
                name: "IX_Events_TwitterSummarysId",
                table: "Events",
                newName: "IX_Events_FilterId");

            migrationBuilder.AddColumn<string>(
                name: "eventName",
                table: "SummaryInformations",
                type: "nvarchar(max)",
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

            migrationBuilder.CreateTable(
                name: "SummaryInformationVM",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Platform = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CountOfPosts = table.Column<int>(type: "int", nullable: false),
                    totalLikes = table.Column<int>(type: "int", nullable: false),
                    totalRetweets = table.Column<int>(type: "int", nullable: false),
                    totalComments = table.Column<int>(type: "int", nullable: false),
                    averageLikes = table.Column<int>(type: "int", nullable: false),
                    averageRetweets = table.Column<int>(type: "int", nullable: false),
                    averageComments = table.Column<int>(type: "int", nullable: false),
                    followerIncrease = table.Column<int>(type: "int", nullable: false),
                    totalFollowers = table.Column<int>(type: "int", nullable: false),
                    eventName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EventId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryInformationVM", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryInformationVM_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SummaryInformationVM_EventId",
                table: "SummaryInformationVM",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FilterVM_FilterId",
                table: "Events",
                column: "FilterId",
                principalTable: "FilterVM",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Events_FilterVM_FilterId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "FilterVM");

            migrationBuilder.DropTable(
                name: "SummaryInformationVM");

            migrationBuilder.DropColumn(
                name: "eventName",
                table: "SummaryInformations");

            migrationBuilder.RenameColumn(
                name: "Hashtag",
                table: "Events",
                newName: "SearchedTerm");

            migrationBuilder.RenameColumn(
                name: "FilterId",
                table: "Events",
                newName: "TwitterSummarysId");

            migrationBuilder.RenameIndex(
                name: "IX_Events_FilterId",
                table: "Events",
                newName: "IX_Events_TwitterSummarysId");

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

            migrationBuilder.AddColumn<Guid>(
                name: "FacebookSummarysId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "LinkedInSummarysId",
                table: "Events",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Events_FacebookSummarysId",
                table: "Events",
                column: "FacebookSummarysId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LinkedInSummarysId",
                table: "Events",
                column: "LinkedInSummarysId");

            migrationBuilder.AddForeignKey(
                name: "FK_Events_FacebookSummarys_FacebookSummarysId",
                table: "Events",
                column: "FacebookSummarysId",
                principalTable: "FacebookSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_LinkedInSummarys_LinkedInSummarysId",
                table: "Events",
                column: "LinkedInSummarysId",
                principalTable: "LinkedInSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_TwitterSummarys_TwitterSummarysId",
                table: "Events",
                column: "TwitterSummarysId",
                principalTable: "TwitterSummarys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
