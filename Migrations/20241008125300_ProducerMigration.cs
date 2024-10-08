using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CinemaMovieWebApplication.Migrations
{
    /// <inheritdoc />
    public partial class ProducerMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_ProducerModel_ProducersId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProducerModel",
                table: "ProducerModel");

            migrationBuilder.RenameTable(
                name: "ProducerModel",
                newName: "Producers");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Producers",
                table: "Producers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Producers_ProducersId",
                table: "Movies",
                column: "ProducersId",
                principalTable: "Producers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Producers_ProducersId",
                table: "Movies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Producers",
                table: "Producers");

            migrationBuilder.RenameTable(
                name: "Producers",
                newName: "ProducerModel");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProducerModel",
                table: "ProducerModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_ProducerModel_ProducersId",
                table: "Movies",
                column: "ProducersId",
                principalTable: "ProducerModel",
                principalColumn: "Id");
        }
    }
}
