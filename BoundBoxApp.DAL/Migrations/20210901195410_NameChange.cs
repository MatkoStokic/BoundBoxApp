using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class NameChange : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "26685988-4c18-4920-963d-02242340ebdd");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "8345a872-3716-4d97-a4ec-7efbab34ae2d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "4cf6d000-c852-49b3-ad8a-388b1f9907d0");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fb524742-301f-4575-a901-0de63a1562b4", "AQAAAAEAACcQAAAAENhXmIW5pC/IOdQngA5kdXYDN5/yW0z32Vg3EzUsmeONKFTh+LKSy4peUXGnBz4ZZA==", "e3f156a1-6e82-42d3-81d7-2094f3d8eec0" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "aa4e5622-4082-4055-946a-ad47d8b17365", "AQAAAAEAACcQAAAAEOUD9F+j1lPYpLhkFNe8evhxftWjNiwjmWjfzV/0mXRbowljjpi24tuEKCwFAz+AeQ==", "e500359d-74c2-4a34-b50d-3c3437bc7094" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa3e08fa-39e7-4755-8d93-da6b78274c72", "AQAAAAEAACcQAAAAEEfQcGiY5QRkSMDFsrrJV5QYOHz0nzSYcmeBi9CLkEWtkXBtwejzc9wLkFnOllSK7Q==", "ff7195c6-c8bc-478f-88c6-02b21d274f03" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "fd04a890-65b7-4a2a-b361-1d864747d556");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "4021de59-a1e6-42be-912d-134423a8980a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "d8ade769-3363-4c88-8586-ca8d24f6065e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "770a22c7-6eb7-4d96-8c72-5d75a81b70c8", "AQAAAAEAACcQAAAAEFTKh/ZhL/BiPecbxj4534TEHg24dqMVpmNRqhDPQvNwmkZaMmxoTBagSzc59RSK7w==", "06e6e4f9-80b6-4ce0-a3bb-c359c03ab572" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "14250e01-bdcf-4c06-a576-98e7f83fb6ff", "AQAAAAEAACcQAAAAELNhClTB2pwCo4nVDixykyEBG3RJf+FfpykflKIx06MG4k7JJ7K5tjZY3LUQbhX+6w==", "bb020650-f154-4a55-9d12-be329be21488" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "887b7156-4530-4be3-a09d-dbafb273733f", "AQAAAAEAACcQAAAAEM6Te8kEbySbZxWTnUdum8Msmwo6PXo7RIUxgyI/FNmGqdiqHtvF3NdO/IFw7CL73Q==", "46d70bb1-c2dd-4605-bf5b-655d6ea8bd9f" });
        }
    }
}
