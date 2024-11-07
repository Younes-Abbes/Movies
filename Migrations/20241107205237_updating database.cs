using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class updatingdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropIndex(
                name: "IX_Customers_MovieId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "MovieId",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Movies",
                newName: "genre_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                newName: "IX_Movies_genre_idId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Genres",
                newName: "GenreName");

            migrationBuilder.RenameColumn(
                name: "memebershiptypeId",
                table: "Customers",
                newName: "memebershipTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_memebershiptypeId",
                table: "Customers",
                newName: "IX_Customers_memebershipTypeId");

            migrationBuilder.AlterColumn<int>(
                name: "memebershipTypeId",
                table: "Customers",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.CreateTable(
                name: "CustomerMovie",
                columns: table => new
                {
                    customersId = table.Column<int>(type: "integer", nullable: false),
                    moviesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerMovie", x => new { x.customersId, x.moviesId });
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Customers_customersId",
                        column: x => x.customersId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CustomerMovie_Movies_moviesId",
                        column: x => x.moviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CustomerMovie_moviesId",
                table: "CustomerMovie",
                column: "moviesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Memebershiptype_memebershipTypeId",
                table: "Customers",
                column: "memebershipTypeId",
                principalTable: "Memebershiptype",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genre_idId",
                table: "Movies",
                column: "genre_idId",
                principalTable: "Genres",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Memebershiptype_memebershipTypeId",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genre_idId",
                table: "Movies");

            migrationBuilder.DropTable(
                name: "CustomerMovie");

            migrationBuilder.RenameColumn(
                name: "genre_idId",
                table: "Movies",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genre_idId",
                table: "Movies",
                newName: "IX_Movies_genreId");

            migrationBuilder.RenameColumn(
                name: "GenreName",
                table: "Genres",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "memebershipTypeId",
                table: "Customers",
                newName: "memebershiptypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Customers_memebershipTypeId",
                table: "Customers",
                newName: "IX_Customers_memebershiptypeId");

            migrationBuilder.AlterColumn<int>(
                name: "memebershiptypeId",
                table: "Customers",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieId",
                table: "Customers",
                type: "integer",
                nullable: true);

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
    }
}
