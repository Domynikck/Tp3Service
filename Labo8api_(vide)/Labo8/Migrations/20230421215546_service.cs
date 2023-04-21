using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class service : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e9eaeec5-7b4a-4a95-a3ba-0c034ec5e5aa", "AQAAAAEAACcQAAAAEGp7Mh2H5fOdqmnHx/+SKLtMF0WrSJgBpIE5Oeo34+v/GPIp83wD4cUl8KQoRZbNjw==", "8840b1e4-c01c-499b-913c-fb4bed100d19" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7811971e-9d63-48c4-88b1-39cd7a26989f", "AQAAAAEAACcQAAAAEKaIMjxnc+v54Jmdpv8KdH5yszqdbLSwHC/nmCrbgikwcjTWPSY3OqMwZqjc4vc8Fw==", "f2df74e9-30eb-4b22-9e81-e933de2b24c2" });
        }
    }
}
