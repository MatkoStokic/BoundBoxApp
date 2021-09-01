using Microsoft.EntityFrameworkCore.Migrations;

namespace BoundBoxApp.DAL.Migrations
{
    public partial class MarkerUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Role",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb7",
                column: "ConcurrencyStamp",
                value: "e94029ee-bd92-4dfe-8417-352a7c4c6def");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
