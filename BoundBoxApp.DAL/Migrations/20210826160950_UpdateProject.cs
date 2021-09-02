using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class UpdateProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForAnnotating",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoundsId",
                table: "Marker",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "XCoords",
                table: "Marker",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "YCoords",
                table: "Marker",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "AnnotatorId",
                table: "Annotation",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Annotation",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "daf9f372-1f30-46cc-8fff-8b766d12419d");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "20e230e9-3eff-45cf-b81a-5becd1183c6e");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "b9b73cef-deb9-4313-91e2-fb6a84cd4081");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "56e4a6ad-d792-474d-9961-e285447d226b", "AQAAAAEAACcQAAAAEOXan/oL/B0+F98ud9vsMUgqpLnEAsOC7GK+H4F4e3R85vm5jVSyR9+PC9pyRwTvNg==", "7a637d36-bf10-4ffc-b0e9-720fb742d4fd" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c43e6c53-8b9b-439b-be0a-39864a6d094a", "AQAAAAEAACcQAAAAEABXjyLIfrC29CUtrexCBPYLecD92dU4VI+rYdsndWYLD7M7qzP8kVSmpZgKnxSPjA==", "c6d9e24b-7c9f-4043-af6f-a5c115f4d29a" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "81c33396-63df-46f8-9927-ed92fb397f03", "AQAAAAEAACcQAAAAEEkJrupSYxwQD8VYXQCDltJ+8/igpVgbgfCmyF4STYLfkVOroylANTzxAs1TLokJ6g==", "335cf0f5-a19a-4a56-a9cb-ca21b7c8aac4" });

            migrationBuilder.CreateIndex(
                name: "IX_Project_OwnerId",
                table: "Project",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_Marker_BoundsId",
                table: "Marker",
                column: "BoundsId");

            migrationBuilder.CreateIndex(
                name: "IX_Bounds_AnnotatorId",
                table: "Annotation",
                column: "AnnotatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Bounds_ProjectId",
                table: "Annotation",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bounds_User_AnnotatorId",
                table: "Annotation",
                column: "AnnotatorId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Bounds_Project_ProjectId",
                table: "Annotation",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Marker_Bounds_BoundsId",
                table: "Marker",
                column: "BoundsId",
                principalTable: "Annotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project",
                column: "OwnerId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bounds_User_AnnotatorId",
                table: "Annotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Bounds_Project_ProjectId",
                table: "Annotation");

            migrationBuilder.DropForeignKey(
                name: "FK_Marker_Bounds_BoundsId",
                table: "Marker");

            migrationBuilder.DropForeignKey(
                name: "FK_Project_User_OwnerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Project_OwnerId",
                table: "Project");

            migrationBuilder.DropIndex(
                name: "IX_Marker_BoundsId",
                table: "Marker");

            migrationBuilder.DropIndex(
                name: "IX_Bounds_AnnotatorId",
                table: "Annotation");

            migrationBuilder.DropIndex(
                name: "IX_Bounds_ProjectId",
                table: "Annotation");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsForAnnotating",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BoundsId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "XCoords",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "YCoords",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "AnnotatorId",
                table: "Annotation");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Annotation");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "113121fa-7576-4cca-aa09-4e6e39f1dc8a");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "f0f75630-36d7-4cc4-971e-8743012fe480");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "25d1fcc2-6745-45cd-bc63-f025880bd68d");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "afcdd987-f165-479d-b771-bda186fee168", "AQAAAAEAACcQAAAAECEMVe5BQdVG9DtrHssX6hSRpnwNBalqqsLI5WWHhlQtq8503+1eYtD4G/CN36Zcqg==", "5c966353-909a-4844-8c66-89d59a875e51" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1e1e1d82-dcd6-4b83-8d48-df09ecfb4cb9", "AQAAAAEAACcQAAAAEJcXO9Vg11RX2zNLRbC2dMlrR2CN5AvGVAJw/ET41IgiPRrP20iTOsllbLKIB7Chhg==", "b53d2016-4b22-4c1f-8d83-ba9146930329" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b7b2de3f-3151-4cc5-a402-d9e5df5391bd", "AQAAAAEAACcQAAAAEGzFVPIkB1S5ajKPqGinhLUUeI2V9E3+z1MI1xMJm+qog1sUAscmwQqE+4ACAW6vhA==", "8100ac7f-7aa5-4c55-bd25-bbbd24d162da" });
        }
    }
}
