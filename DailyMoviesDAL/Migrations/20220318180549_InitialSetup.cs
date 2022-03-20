using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMoviesDAL.Migrations
{
    public partial class InitialSetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrendingMovie",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Vote_Average = table.Column<float>(type: "real", nullable: false),
                    Sync_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendingMovie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetail",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Overview = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Tagline = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Release_Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Backdrop_Path = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    TrendingMovieId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieDetail", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MovieDetail_TrendingMovie_TrendingMovieId",
                        column: x => x.TrendingMovieId,
                        principalTable: "TrendingMovie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Known_For_Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    character = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MovieDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cast_MovieDetail_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalTable: "MovieDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Known_For_Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Job = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MovieDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Crew_MovieDetail_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalTable: "MovieDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    MovieDetailId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Genre_MovieDetail_MovieDetailId",
                        column: x => x.MovieDetailId,
                        principalTable: "MovieDetail",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieDetailId",
                table: "Cast",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MovieDetailId",
                table: "Crew",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieDetailId",
                table: "Genre",
                column: "MovieDetailId");

            migrationBuilder.CreateIndex(
                name: "IX_MovieDetail_TrendingMovieId",
                table: "MovieDetail",
                column: "TrendingMovieId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cast");

            migrationBuilder.DropTable(
                name: "Crew");

            migrationBuilder.DropTable(
                name: "Genre");

            migrationBuilder.DropTable(
                name: "MovieDetail");

            migrationBuilder.DropTable(
                name: "TrendingMovie");
        }
    }
}
