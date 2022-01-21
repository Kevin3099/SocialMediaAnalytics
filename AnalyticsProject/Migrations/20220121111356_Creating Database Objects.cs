using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnalyticsProject.Migrations
{
    public partial class CreatingDatabaseObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FacebookSummarys",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
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
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TwitterSummarys", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SearchedTerm = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateFrom = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    DateTo = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    TwitterSummarysId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FacebookSummarysId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LinkedInSummarysId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_FacebookSummarys_FacebookSummarysId",
                        column: x => x.FacebookSummarysId,
                        principalTable: "FacebookSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_LinkedInSummarys_LinkedInSummarysId",
                        column: x => x.LinkedInSummarysId,
                        principalTable: "LinkedInSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Events_TwitterSummarys_TwitterSummarysId",
                        column: x => x.TwitterSummarysId,
                        principalTable: "TwitterSummarys",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_FacebookSummarysId",
                table: "Events",
                column: "FacebookSummarysId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_LinkedInSummarysId",
                table: "Events",
                column: "LinkedInSummarysId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_TwitterSummarysId",
                table: "Events",
                column: "TwitterSummarysId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "FacebookSummarys");

            migrationBuilder.DropTable(
                name: "LinkedInSummarys");

            migrationBuilder.DropTable(
                name: "TwitterSummarys");
        }
    }
}
