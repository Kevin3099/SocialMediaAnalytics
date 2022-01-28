using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class updatingDatabasetoincludethefacebookandlinkedinData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SummaryInformations",
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
                    totalFollowers = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryInformations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SummaryInformations");
        }
    }
}
