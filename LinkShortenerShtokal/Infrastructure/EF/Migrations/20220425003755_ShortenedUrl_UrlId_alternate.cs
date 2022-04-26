using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LinkShortenerShtokal.Infrastructure.EF.Migrations
{
    public partial class ShortenedUrl_UrlId_alternate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_Urls_UrlId",
                table: "Urls",
                column: "UrlId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_Urls_UrlId",
                table: "Urls");
        }
    }
}
