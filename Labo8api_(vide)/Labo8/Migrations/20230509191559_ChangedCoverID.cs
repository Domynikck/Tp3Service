using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class ChangedCoverID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1256353f-3f19-4a04-b098-7ff9cd223290", "AQAAAAEAACcQAAAAEDYDzichZ7P71oimSw6PKPgwnk1nhitAOtmAR3WqZ+cqaKzpIXkMw9ya3cU/odv5wQ==", "f0f3ba86-e775-4855-9e56-4baa2d0cb119" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6ac77c2d-9d78-46c1-824c-3eb9707d92f9", "AQAAAAEAACcQAAAAEPUncLkerU2LMqKgGSfOaVfdmS9tHnrWaP5We0Pjs+JrTWHAiKohKBeTlEtPwbVpCg==", "1d48bc33-891d-4549-a4d7-75a0fe17045e" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
