using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class AddedOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "Marker",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "a8546ed9-79ac-481b-9b3f-3d8d3c2200bc");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "5738708a-97f8-48ba-af44-890c91bee9ed");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "6e742c74-41b0-4f7d-822d-5539d6d59905");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "db536b12-64ff-43e7-ba70-ab4cca6aee55", "AQAAAAEAACcQAAAAEGwQav/nWcdb8Px+HBvalRE2F0iAVeaA8VRjEl/0y1e91qpmG+tL8uHVyD+tV2swVg==", "beef6b8c-69e4-4e2c-b6f4-cf84ed3fd0a9" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "02152fe1-c4fc-4215-adc8-08c9dae5ff4b", "AQAAAAEAACcQAAAAEM96qSPRFoJfzPlYoUWGcl5kDHqP8V7N3nmYckbT+zLOVBvd6jIRS/IjVBt58FgeEg==", "f7ce3d43-bf87-4b7d-aa8e-c0599ee4fc0a" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "266be7d3-4b21-4e54-b128-658a64256d52", "AQAAAAEAACcQAAAAEDAAJB/4S2P+e+lSu/wQY87LfKPb9FNf1y6jkcJl8/SDrtAn9Oi1QDGFiSoKVeuFbw==", "3b69379f-9847-4a5a-b518-44bef5a5cd7a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Order",
                table: "Marker");

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
    }
}
