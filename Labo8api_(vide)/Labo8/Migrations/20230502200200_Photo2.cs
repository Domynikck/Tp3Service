using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class Photo2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "imageUrl",
                table: "Photo");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "00142de3-b7b2-48bd-a689-579c48dfd26b", "AQAAAAEAACcQAAAAEEhxx1PJ9Tsewrq6jfm0DPLiHkN0C32Iaf+KkFYUp0Cp4vAM6V2b70I1WAGTJtfIvw==", "d13dad0f-02ee-4294-88b4-2afcaecdfb23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "71b731ef-2e2d-4a6e-b7b2-cabf34bf2dcb", "AQAAAAEAACcQAAAAEHssGqtdsNvHgOrWchQ6Ffh1kEYr6c5f8Fp4jHs600d42nps9MpZ+p1ajBsJO8LjLQ==", "9c220f9f-593d-46f0-a01b-aaa274937f12" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "imageUrl",
                table: "Photo",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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
        }
    }
}
