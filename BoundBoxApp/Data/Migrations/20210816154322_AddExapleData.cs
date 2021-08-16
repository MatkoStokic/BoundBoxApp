using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.Data.Migrations
{
    public partial class AddExapleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", "a230e9b5-9d78-4489-a9c8-6ebc627e4a99", "Admin", "ADMIN" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb8", "75414d00-b41e-45ac-8fe1-59c56387b64d", "Annotator", "ANNOTATOR" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", "71fce38c-f113-4165-ba43-8589f2180292", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "8e445865-a24d-4543-a6c6-9443d048cdb9", 0, "c4e9b004-5d7f-4d41-8f71-09335aeaad52", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "Admin", "AQAAAAEAACcQAAAAEFTQWNM+KgTEam6lKA/yHRigeqhb94wW6dHrRvdxuQnYJSc3dgbr3qDSyDkxZGlFsA==", "", true, "8d57fd0b-9da6-477b-8470-f971129dcccb", false, "Admin" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb8", 0, "b75c60a9-2a29-4b67-b2b9-e40123c36c2c", "annotator@annotator.com", true, false, null, "ANNOTATOR@ANNOTATOR.COM", "Annotator", "AQAAAAEAACcQAAAAEDaY7/uE1CBIgTmJuLBvN4ZgvVgGWdNJ2AQYR8KJOboMAisT33nWVnhMpiO3EV/MNw==", "", true, "42399d1e-c7f5-4001-b1b2-78d95617ef83", false, "Annotator" },
                    { "8e445865-a24d-4543-a6c6-9443d048cdb7", 0, "dbf5ba92-0137-4697-a259-8986b2a1208e", "user@user.com", true, false, null, "USER@USER.COM", "User", "AQAAAAEAACcQAAAAEHTg+P7Cj5EfnEuBDqe0dKxk/GruAIRX/sCFad8qpCg+Iru96PsZssvqmzBPp4GV+g==", "", true, "1659ad46-599f-4e68-9f8d-dbef3f7ae2c7", false, "User" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb8", "8e445865-a24d-4543-a6c6-9443d048cdb8" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb7", "8e445865-a24d-4543-a6c6-9443d048cdb7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb7", "8e445865-a24d-4543-a6c6-9443d048cdb7" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb8", "8e445865-a24d-4543-a6c6-9443d048cdb8" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8e445865-a24d-4543-a6c6-9443d048cdb9", "8e445865-a24d-4543-a6c6-9443d048cdb9" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9");
        }
    }
}
