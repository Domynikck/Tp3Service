using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class Photo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Photo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    imageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MimeType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    GallerieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Photo_Gallerie_GallerieId",
                        column: x => x.GallerieId,
                        principalTable: "Gallerie",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f497a547-47ec-483c-90ed-0d9e6d83a0fb", "AQAAAAEAACcQAAAAELtiIajYhvtfFdiTS3rGA4+o5KXxPEJlKlyvSnOlPknC91TNpcyNLIbtDAPlczBWiA==", "526ca0a4-4096-44ba-8d4e-1f2aa0934b5b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "003a3caa-125b-416c-b586-d5577d5fa0b4", "AQAAAAEAACcQAAAAEK2zBl9vdMxmF6OcpdB377N6VPeGLHngFAvT7TvuyZI9gEmIYOlbKf2jJDWwB7zuBg==", "69a90d36-6418-4f08-ba22-1fe5849f7c7e" });

            migrationBuilder.CreateIndex(
                name: "IX_Photo_GallerieId",
                table: "Photo",
                column: "GallerieId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Photo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "627bb772-c181-4927-b880-9adabb3c5813", "AQAAAAEAACcQAAAAEGOVT96w324tnVA9DngFhD12S6sNgWOcj6rbpqsMjrf7PnYCxtzqmFf1PEbH0fp/jw==", "7ed88c66-2dc4-4daf-bd3a-45675f7a8d1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f3165e00-d13f-49ba-9b69-c54a5250c0ac", "AQAAAAEAACcQAAAAEMnesoxMrVhiDYvW2JmnWhYlrBBE/8xRrHCcM7xrlUBp+3/56dBtnfa2nM/KBn8W6Q==", "4addfac7-1677-4baa-9ba4-bf1a4b58f958" });
        }
    }
}
