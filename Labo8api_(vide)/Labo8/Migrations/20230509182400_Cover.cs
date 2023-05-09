using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class Cover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "828d0378-e610-4574-8641-3e7688d9339c", "AQAAAAEAACcQAAAAEIgiZ2zW+RaTszSG+sJQxFfqt0Zg1Ee1g51R3yKzkW3AnX9BppnChtPDcVxHNyxdyg==", "f8e10ae8-8e57-464f-abe4-d4403ce6cae3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f7f9a916-e266-4b0c-b91e-e244a106449b", "AQAAAAEAACcQAAAAEF6Uv/KCCUs9aJMF8bsfUC+goN6CM7XfbflB8JK1x1e3KGLWwQdbtECh5UNV0w6SlQ==", "6350d725-06a0-464f-9830-b72a7d13118f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
