using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class FixingDatabasemodelsandaddingfakelinkedinandfacebookdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "FacebookSummarys");

            migrationBuilder.AddColumn<int>(
                name: "CountOfPosts",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateFrom",
                table: "TwitterSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTo",
                table: "TwitterSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "averageComments",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageLikes",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageRetweets",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "followerIncrease",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalComments",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalFollowers",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalRetweets",
                table: "TwitterSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfPosts",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateFrom",
                table: "LinkedInSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTo",
                table: "LinkedInSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "averageComments",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageLikes",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageRetweets",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "followerIncrease",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalComments",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalFollowers",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalRetweets",
                table: "LinkedInSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CountOfPosts",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateFrom",
                table: "FacebookSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "DateTo",
                table: "FacebookSummarys",
                type: "datetimeoffset",
                nullable: false,
                defaultValue: new DateTimeOffset(new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new TimeSpan(0, 0, 0, 0, 0)));

            migrationBuilder.AddColumn<int>(
                name: "averageComments",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageLikes",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "averageRetweets",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "followerIncrease",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalComments",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalFollowers",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalLikes",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "totalRetweets",
                table: "FacebookSummarys",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FacebookDbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePosted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes = table.Column<int>(type: "int", nullable: false),
                    retweets = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacebookDbs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkedInDbs",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DatePosted = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    likes = table.Column<int>(type: "int", nullable: false),
                    retweets = table.Column<int>(type: "int", nullable: false),
                    comments = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedInDbs", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacebookDbs");

            migrationBuilder.DropTable(
                name: "LinkedInDbs");

            migrationBuilder.DropColumn(
                name: "CountOfPosts",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "averageComments",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "averageLikes",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "averageRetweets",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "followerIncrease",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "totalComments",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "totalFollowers",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "totalRetweets",
                table: "TwitterSummarys");

            migrationBuilder.DropColumn(
                name: "CountOfPosts",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "averageComments",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "averageLikes",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "averageRetweets",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "followerIncrease",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "totalComments",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "totalFollowers",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "totalRetweets",
                table: "LinkedInSummarys");

            migrationBuilder.DropColumn(
                name: "CountOfPosts",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "DateFrom",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "DateTo",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "averageComments",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "averageLikes",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "averageRetweets",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "followerIncrease",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "totalComments",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "totalFollowers",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "totalLikes",
                table: "FacebookSummarys");

            migrationBuilder.DropColumn(
                name: "totalRetweets",
                table: "FacebookSummarys");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "TwitterSummarys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "LinkedInSummarys",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "FacebookSummarys",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
