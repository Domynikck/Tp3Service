using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Labo8.Migrations
{
    public partial class ChangedCoverID2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CoverID",
                table: "Gallerie",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111111",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "976f9b83-69b5-4946-875f-c49ad5c40b68", "AQAAAAEAACcQAAAAEGfZ/2LEA8xFj0bwQ12zUALZqvkbSqx4mxl5XnmIE/mDTgiFICKd1jy8zrH/WXtzuQ==", "d6ca1cdd-bb89-4727-9938-86a9eabe411d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "11111111-1111-1111-1111-111111111112",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b51376a-fef8-4d28-9241-42958934e07a", "AQAAAAEAACcQAAAAEPysDD+yrM0iRXgiRUeZr4f+vdLl45DtqldU4SiBB+iOWKpVynq8j5vokue1MPgs+g==", "c28e9005-1bb5-4a84-82de-beabb4d15d93" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverID",
                table: "Gallerie");

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
    }
}
