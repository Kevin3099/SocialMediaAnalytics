using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class MachineLearning : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacebookSummarys");

            migrationBuilder.DropTable(
                name: "LinkedInSummarys");

            migrationBuilder.DropTable(
                name: "TwitterSummarys");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacebookSummarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountOfPosts = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    averageComments = table.Column<int>(type: "int", nullable: false),
                    averageLikes = table.Column<int>(type: "int", nullable: false),
                    averageRetweets = table.Column<int>(type: "int", nullable: false),
                    followerIncrease = table.Column<int>(type: "int", nullable: false),
                    totalComments = table.Column<int>(type: "int", nullable: false),
                    totalFollowers = table.Column<int>(type: "int", nullable: false),
                    totalLikes = table.Column<int>(type: "int", nullable: false),
                    totalRetweets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacebookSummarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LinkedInSummarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountOfPosts = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    averageComments = table.Column<int>(type: "int", nullable: false),
                    averageLikes = table.Column<int>(type: "int", nullable: false),
                    averageRetweets = table.Column<int>(type: "int", nullable: false),
                    followerIncrease = table.Column<int>(type: "int", nullable: false),
                    totalComments = table.Column<int>(type: "int", nullable: false),
                    totalFollowers = table.Column<int>(type: "int", nullable: false),
                    totalLikes = table.Column<int>(type: "int", nullable: false),
                    totalRetweets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinkedInSummarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TwitterSummarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountOfPosts = table.Column<int>(type: "int", nullable: false),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    averageComments = table.Column<int>(type: "int", nullable: false),
                    averageLikes = table.Column<int>(type: "int", nullable: false),
                    averageRetweets = table.Column<int>(type: "int", nullable: false),
                    followerIncrease = table.Column<int>(type: "int", nullable: false),
                    totalComments = table.Column<int>(type: "int", nullable: false),
                    totalFollowers = table.Column<int>(type: "int", nullable: false),
                    totalLikes = table.Column<int>(type: "int", nullable: false),
                    totalRetweets = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterSummarys", x => x.Id);
                });
        }
    }
}
