using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class MultipleCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marker_Bounds_BoundsId",
                table: "Marker");

            migrationBuilder.DropIndex(
                name: "IX_Marker_BoundsId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsForAnnotating",
                table: "Project");

            migrationBuilder.AddColumn<string>(
                name: "Categories",
                table: "Project",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForObjectDetection",
                table: "Project",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "BoundsId",
                table: "Marker",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AnnotationId",
                table: "Marker",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Annotation",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsObjectDetection",
                table: "Annotation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd04a890-65b7-4a2a-b361-1d864747d556", "ContentOwner", "CONTENTOWNER" });

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

            migrationBuilder.CreateIndex(
                name: "IX_Marker_AnnotationId",
                table: "Marker",
                column: "AnnotationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marker_Annotation_AnnotationId",
                table: "Marker",
                column: "AnnotationId",
                principalTable: "Annotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Marker_Annotation_AnnotationId",
                table: "Marker");

            migrationBuilder.DropIndex(
                name: "IX_Marker_AnnotationId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "Categories",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsForObjectDetection",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "AnnotationId",
                table: "Marker");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Annotation");

            migrationBuilder.DropColumn(
                name: "IsObjectDetection",
                table: "Annotation");

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsForAnnotating",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "BoundsId",
                table: "Marker",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e94029ee-bd92-4dfe-8417-352a7c4c6def", "User", "USER" });

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                column: "ConcurrencyStamp",
                value: "d1717909-e17a-4dd7-9171-55becd125392");

            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                column: "ConcurrencyStamp",
                value: "426a287c-6b3e-4724-80ab-80f7bf212f65");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "98db8910-d830-4098-ad74-be16e8f28277", "AQAAAAEAACcQAAAAELT6NVs0VuCzXv0KqKW+8dLrRTGqdKeN0C3fhLIdfOAUJtd4V0uWsbtI2rTktcyIhQ==", "06435e42-ba3f-4396-8118-bfed5b3915a6" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb8",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "37d298b4-e26f-4ae4-9d14-caee4dce67aa", "AQAAAAEAACcQAAAAEL3+gmpuELTXJoRikemYEboQ2RROmOTYr7wAzbaQ35vfYbtlVOaHoaT9QaE6iRUu3g==", "196a33f1-f917-4425-8e76-f754faf3c5c3" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "89b738dc-412b-420b-9edf-fcda8a728ecc", "AQAAAAEAACcQAAAAEPMbHuysHlW0AtRXO7meD+kVXnWRkWEMDdGea2MBHr4tOsUHN39pcoMpxCoUaN3m0g==", "6be88a52-5323-4e1f-a44a-83533e451f8d" });

            migrationBuilder.CreateIndex(
                name: "IX_Marker_BoundsId",
                table: "Marker",
                column: "BoundsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Marker_Bounds_BoundsId",
                table: "Marker",
                column: "BoundsId",
                principalTable: "Annotation",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
