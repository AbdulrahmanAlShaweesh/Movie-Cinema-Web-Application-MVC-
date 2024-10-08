using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ActorMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AwardCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CinemaModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    OpeningHours = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CinemaModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProducerModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProducerProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProducerModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    MovieUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoviePoster = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MovieTypes = table.Column<int>(type: "int", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Director = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductionCompany = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProducerId = table.Column<int>(type: "int", nullable: false),
                    ProducersId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieModel_ProducerModel_ProducersId",
                        column: x => x.ProducersId,
                        principalTable: "ProducerModel",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ActorMovieModel",
                columns: table => new
                {
                    ActorId = table.Column<int>(type: "int", nullable: false),
                    MovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovieModel", x => new { x.ActorId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_ActorMovieModel_Actors_ActorId",
                        column: x => x.ActorId,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovieModel_MovieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCinemaModel",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    CinemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCinemaModel", x => new { x.MovieId, x.CinemaId });
                    table.ForeignKey(
                        name: "FK_MovieCinemaModel_CinemaModel_CinemaId",
                        column: x => x.CinemaId,
                        principalTable: "CinemaModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCinemaModel_MovieModel_MovieId",
                        column: x => x.MovieId,
                        principalTable: "MovieModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovieModel_MovieId",
                table: "ActorMovieModel",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCinemaModel_CinemaId",
                table: "MovieCinemaModel",
                column: "CinemaId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieModel_ProducersId",
                table: "MovieModel",
                column: "ProducersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovieModel");

            migrationBuilder.DropTable(
                name: "MovieCinemaModel");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "CinemaModel");

            migrationBuilder.DropTable(
                name: "MovieModel");

            migrationBuilder.DropTable(
                name: "ProducerModel");
        }
    }
}
