using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class MovieCinemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_Cinemas_CinemaId",
                table: "MovieCinemaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_Movies_MovieId",
                table: "MovieCinemaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCinemaModel",
                table: "MovieCinemaModel");

            migrationBuilder.RenameTable(
                name: "MovieCinemaModel",
                newName: "MovieCinema");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCinemaModel_CinemaId",
                table: "MovieCinema",
                newName: "IX_MovieCinema_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCinema",
                table: "MovieCinema",
                columns: new[] { "MovieId", "CinemaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinema_Cinemas_CinemaId",
                table: "MovieCinema",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinema_Movies_MovieId",
                table: "MovieCinema",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinema_Cinemas_CinemaId",
                table: "MovieCinema");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinema_Movies_MovieId",
                table: "MovieCinema");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieCinema",
                table: "MovieCinema");

            migrationBuilder.RenameTable(
                name: "MovieCinema",
                newName: "MovieCinemaModel");

            migrationBuilder.RenameIndex(
                name: "IX_MovieCinema_CinemaId",
                table: "MovieCinemaModel",
                newName: "IX_MovieCinemaModel_CinemaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieCinemaModel",
                table: "MovieCinemaModel",
                columns: new[] { "MovieId", "CinemaId" });

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_Cinemas_CinemaId",
                table: "MovieCinemaModel",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_Movies_MovieId",
                table: "MovieCinemaModel",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
