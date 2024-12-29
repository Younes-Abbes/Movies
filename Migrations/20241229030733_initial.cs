using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    GenreName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "memebershipTypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    SignUpFee = table.Column<int>(type: "integer", nullable: false),
                    DurationInMonth = table.Column<int>(type: "integer", nullable: false),
                    DiscountRate = table.Column<float>(type: "real", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_memebershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    genre_idId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_genre_idId",
                        column: x => x.genre_idId,
                        principalTable: "Genres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    membershipTypeId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Customers_memebershipTypes_membershipTypeId",
                        column: x => x.membershipTypeId,
                        principalTable: "memebershipTypes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CustomerMovie",
                columns: table => new
                {
                    customersId = table.Column<Guid>(type: "uuid", nullable: false),
                    moviesId = table.Column<Guid>(type: "uuid", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Customers_membershipTypeId",
                table: "Customers",
                column: "membershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_genre_idId",
                table: "Movies",
                column: "genre_idId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CustomerMovie");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "memebershipTypes");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}
