using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class MultipleImages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bounds_Project_ProjectId",
                table: "Annotation");

            migrationBuilder.DropIndex(
                name: "IX_Bounds_ProjectId",
                table: "Annotation");

            migrationBuilder.DropColumn(
                name: "Src",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "BoundsId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Annotation");

            migrationBuilder.AddColumn<string>(
                name: "AnnotationsId",
                table: "Marker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ImageId",
                table: "Annotation",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Image",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Src = table.Column<string>(nullable: true),
                    ProjectId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Image", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Image_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "7197e093-854e-49e5-a1cc-75767e9f367c");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "52cc64d7-9dc1-4f49-af89-38c9c5418728");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "eeb85890-e07f-4295-b53c-f7c3f07ed99a");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "76fa1e16-0951-4de7-a848-a71a368d2e66", "AQAAAAEAACcQAAAAEBElbnMhavZQmM1bzdNkepVwcYMqTDRy3vhqDOtpi/fIK/8SgNZoVRIpnldnj8Ly8Q==", "5896c610-dd45-4cc0-8b0e-bd03955e14f9" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "0af4b47b-4fdd-4841-bc81-41f87b19927b", "AQAAAAEAACcQAAAAELnTztvdeTtuBGJ5kSgIemynN41riw0SoVpX/bSFuxGm1QSOhXE8i5apI1rt1mCp0w==", "5c636b5c-c1e6-4219-8f7a-a26e994b1c75" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ad2a587-d90e-4cd9-9652-a20e9050920f", "AQAAAAEAACcQAAAAEMuakQXOOIM6yv1DK6RzpE/tnfCJq17ts9n1ouh8D/Ode1nbKBgFgJDNTfo2i7ocRw==", "671916f3-9983-41ff-996e-314d1616a790" });

            migrationBuilder.CreateIndex(
                name: "IX_Annotation_ImageId",
                table: "Annotation",
                column: "ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_Image_ProjectId",
                table: "Image",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Annotation_Image_ImageId",
                table: "Annotation",
                column: "ImageId",
                principalTable: "Image",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Annotation_Image_ImageId",
                table: "Annotation");

            migrationBuilder.DropTable(
                name: "Image");

            migrationBuilder.DropIndex(
                name: "IX_Annotation_ImageId",
                table: "Annotation");

            migrationBuilder.DropColumn(
                name: "AnnotationsId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "ImageId",
                table: "Annotation");

            migrationBuilder.AddColumn<string>(
                name: "Src",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BoundsId",
                table: "Marker",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProjectId",
                table: "Annotation",
                type: "nvarchar(450)",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Bounds_ProjectId",
                table: "Annotation",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bounds_Project_ProjectId",
                table: "Annotation",
                column: "ProjectId",
                principalTable: "Project",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
