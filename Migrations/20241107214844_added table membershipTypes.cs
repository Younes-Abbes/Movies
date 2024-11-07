using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addedtablemembershipTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Memebershiptype_memebershipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Memebershiptype",
                table: "Memebershiptype");

            migrationBuilder.RenameTable(
                name: "Memebershiptype",
                newName: "memebershipTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_memebershipTypes",
                table: "memebershipTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_memebershipTypes_memebershipTypeId",
                table: "Customers",
                column: "memebershipTypeId",
                principalTable: "memebershipTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_memebershipTypes_memebershipTypeId",
                table: "Customers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_memebershipTypes",
                table: "memebershipTypes");

            migrationBuilder.RenameTable(
                name: "memebershipTypes",
                newName: "Memebershiptype");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Memebershiptype",
                table: "Memebershiptype",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Memebershiptype_memebershipTypeId",
                table: "Customers",
                column: "memebershipTypeId",
                principalTable: "Memebershiptype",
                principalColumn: "Id");
        }
    }
}
