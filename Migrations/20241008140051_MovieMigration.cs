using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class MovieMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieModel_MovieModel_MovieId",
                table: "ActorMovieModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_MovieModel_MovieId",
                table: "MovieCinemaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieModel_ProducerModel_ProducersId",
                table: "MovieModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MovieModel",
                table: "MovieModel");

            migrationBuilder.RenameTable(
                name: "MovieModel",
                newName: "Movies");

            migrationBuilder.RenameIndex(
                name: "IX_MovieModel_ProducersId",
                table: "Movies",
                newName: "IX_Movies_ProducersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movies",
                table: "Movies",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieModel_Movies_MovieId",
                table: "ActorMovieModel",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_Movies_MovieId",
                table: "MovieCinemaModel",
                column: "MovieId",
                principalTable: "Movies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ProducerModel_ProducersId",
                table: "Movies",
                column: "ProducersId",
                principalTable: "ProducerModel",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActorMovieModel_Movies_MovieId",
                table: "ActorMovieModel");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_Movies_MovieId",
                table: "MovieCinemaModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ProducerModel_ProducersId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Movies",
                table: "Movies");

            migrationBuilder.RenameTable(
                name: "Movies",
                newName: "MovieModel");

            migrationBuilder.RenameIndex(
                name: "IX_Movies_ProducersId",
                table: "MovieModel",
                newName: "IX_MovieModel_ProducersId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MovieModel",
                table: "MovieModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ActorMovieModel_MovieModel_MovieId",
                table: "ActorMovieModel",
                column: "MovieId",
                principalTable: "MovieModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_MovieModel_MovieId",
                table: "MovieCinemaModel",
                column: "MovieId",
                principalTable: "MovieModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MovieModel_ProducerModel_ProducersId",
                table: "MovieModel",
                column: "ProducersId",
                principalTable: "ProducerModel",
                principalColumn: "Id");
        }
    }
}
