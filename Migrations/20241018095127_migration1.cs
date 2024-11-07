using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class migration1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "genreId",
                table: "Movies",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Customers",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "memebershiptypeId",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Memebershiptype",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SignUpFee = table.Column<int>(type: "integer", nullable: false),
                    DurationInMonth = table.Column<int>(type: "integer", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memebershiptype", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                column: "genreId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_memebershiptypeId",
                table: "Customers",
                column: "memebershiptypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_MovieId",
                table: "Customers",
                column: "MovieId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Memebershiptype_memebershiptypeId",
                table: "Customers",
                column: "memebershiptypeId",
                principalTable: "Memebershiptype",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Movies_MovieId",
                table: "Customers",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies",
                column: "genreId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Memebershiptype_memebershiptypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Movies_MovieId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genreId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "Memebershiptype");

            migrationBuilder.DropIndex(
                name: "IX_Movies_genreId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Customers_memebershiptypeId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Customers_MovieId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "genreId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "memebershiptypeId",
                table: "Customers");
        }
    }
}
