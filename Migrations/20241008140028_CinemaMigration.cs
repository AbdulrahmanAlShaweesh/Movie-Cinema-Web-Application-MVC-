using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class CinemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_CinemaModel_CinemaId",
                table: "MovieCinemaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CinemaModel",
                table: "CinemaModel");

            migrationBuilder.RenameTable(
                name: "CinemaModel",
                newName: "Cinemas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_Cinemas_CinemaId",
                table: "MovieCinemaModel",
                column: "CinemaId",
                principalTable: "Cinemas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCinemaModel_Cinemas_CinemaId",
                table: "MovieCinemaModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cinemas",
                table: "Cinemas");

            migrationBuilder.RenameTable(
                name: "Cinemas",
                newName: "CinemaModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CinemaModel",
                table: "CinemaModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCinemaModel_CinemaModel_CinemaId",
                table: "MovieCinemaModel",
                column: "CinemaId",
                principalTable: "CinemaModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
