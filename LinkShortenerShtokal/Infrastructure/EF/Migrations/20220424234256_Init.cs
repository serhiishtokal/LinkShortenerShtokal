using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkShortenerShtokal.Infrastructure.EF.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Urls",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UrlId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OriginalUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrlAlias = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    NumberOfUsages = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Urls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RedirectRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RemoteIpAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortenedUrlId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RedirectRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RedirectRequests_Urls_ShortenedUrlId",
                        column: x => x.ShortenedUrlId,
                        principalTable: "Urls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RedirectRequests_ShortenedUrlId",
                table: "RedirectRequests",
                column: "ShortenedUrlId");

            migrationBuilder.CreateIndex(
                name: "IX_Urls_UrlAlias",
                table: "Urls",
                column: "UrlAlias",
                unique: true,
                filter: "[UrlAlias] IS NOT NULL");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RedirectRequests");

            migrationBuilder.DropTable(
                name: "Urls");
        }
    }
}
