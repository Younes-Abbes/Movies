using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class addedimdbid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_genre_idId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genre_idId",
                table: "Movies",
                newName: "genreId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genre_idId",
                table: "Movies",
                newName: "IX_Movies_genreId");

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
                name: "FK_Movies_Genres_genreId",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "genreId",
                table: "Movies",
                newName: "genre_idId");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_genreId",
                table: "Movies",
                newName: "IX_Movies_genre_idId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_genre_idId",
                table: "Movies",
                column: "genre_idId",
                principalTable: "Genres",
                principalColumn: "Id");
        }
    }
}
