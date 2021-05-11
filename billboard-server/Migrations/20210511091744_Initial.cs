using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace billboard_server.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SongHits",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Rank = table.Column<int>(type: "integer", nullable: false),
                    LastWeekRank = table.Column<int>(type: "integer", nullable: false),
                    PeakRank = table.Column<int>(type: "integer", nullable: false),
                    WeeksOnBoard = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Artist = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongHits", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SongHits");
        }
    }
}
