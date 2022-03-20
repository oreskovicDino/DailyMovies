using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DailyMoviesDAL.Migrations
{
    public partial class DatabaseTableColumnFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TrendingMovie",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    Vote_Average = table.Column<float>(type: "real", nullable: false),
                    Sync_Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrendingMovie", x => x.MovieId);
                });

            migrationBuilder.CreateTable(
                name: "MovieDetail",
                columns: table => new
                {
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
                    table.PrimaryKey("PK_MovieDetail", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_MovieDetail_TrendingMovie_TrendingMovieId",
                        column: x => x.TrendingMovieId,
                        principalTable: "TrendingMovie",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cast",
                columns: table => new
                {
                    CastId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Known_For_Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Character = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MovieDetailMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cast", x => x.CastId);
                    table.ForeignKey(
                        name: "FK_Cast_MovieDetail_MovieDetailMovieId",
                        column: x => x.MovieDetailMovieId,
                        principalTable: "MovieDetail",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Crew",
                columns: table => new
                {
                    CrewId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    Known_For_Department = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    Job = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true),
                    MovieDetailMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Crew", x => x.CrewId);
                    table.ForeignKey(
                        name: "FK_Crew_MovieDetail_MovieDetailMovieId",
                        column: x => x.MovieDetailMovieId,
                        principalTable: "MovieDetail",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Genre",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: true),
                    MovieDetailMovieId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genre", x => x.GenreId);
                    table.ForeignKey(
                        name: "FK_Genre_MovieDetail_MovieDetailMovieId",
                        column: x => x.MovieDetailMovieId,
                        principalTable: "MovieDetail",
                        principalColumn: "MovieId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cast_MovieDetailMovieId",
                table: "Cast",
                column: "MovieDetailMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Crew_MovieDetailMovieId",
                table: "Crew",
                column: "MovieDetailMovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Genre_MovieDetailMovieId",
                table: "Genre",
                column: "MovieDetailMovieId");

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
