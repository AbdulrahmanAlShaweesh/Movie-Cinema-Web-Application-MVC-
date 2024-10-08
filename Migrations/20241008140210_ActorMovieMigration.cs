using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ActorMovieMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieModel_Actors_ActorId",
                table: "ActorMovieModel");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieModel_Movies_MovieId",
                table: "ActorMovieModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovieModel",
                table: "ActorMovieModel");

            migrationBuilder.RenameTable(
                name: "ActorMovieModel",
                newName: "ActorMovies");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovieModel_MovieId",
                table: "ActorMovies",
                newName: "IX_ActorMovies_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Actors_ActorId",
                table: "ActorMovies");

            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovies_Movies_MovieId",
                table: "ActorMovies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ActorMovies",
                table: "ActorMovies");

            migrationBuilder.RenameTable(
                name: "ActorMovies",
                newName: "ActorMovieModel");

            migrationBuilder.RenameIndex(
                name: "IX_ActorMovies_MovieId",
                table: "ActorMovieModel",
                newName: "IX_ActorMovieModel_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ActorMovieModel",
                table: "ActorMovieModel",
                columns: new[] { "ActorId", "MovieId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieModel_Actors_ActorId",
                table: "ActorMovieModel",
                column: "ActorId",
                principalTable: "Actors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieModel_Movies_MovieId",
                table: "ActorMovieModel",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
