using Microsoft.EntityFrameworkCore.Migrations;

namespace WebChat.Migrations
{
    public partial class InsertedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36ef9016-4914-4c6a-8f1e-950448dec2b9", "a458c7a7-ffce-42c7-a5cb-136462d8e66e", "Korisnik", "KORISNIK" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5abcc280-8d09-4214-95ce-b440c22b5d3f", "dbbffe10-3814-4e11-9825-923815a950af", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "8b08d7c1-cfcd-4629-953f-9e9228144cfb", "d30f5acf-b18d-4d7f-bc8a-907808220d76", "Moderator", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36ef9016-4914-4c6a-8f1e-950448dec2b9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5abcc280-8d09-4214-95ce-b440c22b5d3f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8b08d7c1-cfcd-4629-953f-9e9228144cfb");
        }
    }
}
