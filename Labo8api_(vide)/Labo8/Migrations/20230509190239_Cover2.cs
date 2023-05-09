using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class Cover2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e0b1bffe-08a0-457b-a249-57c76d118a33", "AQAAAAEAACcQAAAAEHjPVpxiOEcfEKdrGcfiBCZ0JtIluqc9ZQVQmYTeV0vgjYnUR0do5QdilRRjc9zMtA==", "511ecfbd-c331-4908-a100-69e9e8b62be6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "52bb37fa-366e-4110-a8c9-de32dd891f35", "AQAAAAEAACcQAAAAEEjHXWtievqZpdZr54+9NVdoIiKscmLFlCIbIC1yybUR7unnKjcsNn6foG+trUXXPg==", "775f4bbb-3ac4-483e-86c0-c8f82fa843b3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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
    }
}
