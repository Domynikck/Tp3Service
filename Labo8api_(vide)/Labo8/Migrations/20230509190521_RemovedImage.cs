using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class RemovedImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Gallerie");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e8bed156-1013-4576-978d-5051e34e3271", "AQAAAAEAACcQAAAAENEIdXTnLnkpL+w8+qc6ciSBDggi1iYAv9enx1WiT/vGJLYsQbX6MQWMAOQHbjf0vg==", "9610dc0b-a85d-4378-8777-211afffb5d85" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8e091625-3c38-44be-a30f-2533cba96b1e", "AQAAAAEAACcQAAAAECDIJI2WvFWOWE23jLoV8XaPnWHEv21BxjKylXQC47xtbcdvGIi/8wdGBKbiiRMOMw==", "9ec9c05e-c1df-4582-86cf-be27bd6c27ea" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Gallerie",
                type: "nvarchar(max)",
                nullable: true);

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
    }
}
