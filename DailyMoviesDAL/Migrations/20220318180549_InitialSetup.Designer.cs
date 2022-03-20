﻿// <auto-generated />
using System;
using DailyMoviesDAL.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DailyMoviesDAL.Migrations
{
    [DbContext(typeof(ApplicationDbContex))]
    [Migration("20220318180549_InitialSetup")]
    partial class InitialSetup
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DailyMoviesDAL.Models.Cast", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Known_For_Department")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("MovieDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<string>("character")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("Cast");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Job")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Known_For_Department")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("MovieDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("Crew");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("MovieDetailId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.HasKey("Id");

                    b.HasIndex("MovieDetailId");

                    b.ToTable("Genre");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.MovieDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Backdrop_Path")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Overview")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("Release_Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Tagline")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Title")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)");

                    b.Property<int>("TrendingMovieId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrendingMovieId")
                        .IsUnique();

                    b.ToTable("MovieDetail");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.TrendingMovie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Sync_Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Vote_Average")
                        .HasColumnType("real");

                    b.HasKey("Id");

                    b.ToTable("TrendingMovie");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.Cast", b =>
                {
                    b.HasOne("DailyMoviesDAL.Models.MovieDetail", "MovieDetail")
                        .WithMany("Cast")
                        .HasForeignKey("MovieDetailId");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.Crew", b =>
                {
                    b.HasOne("DailyMoviesDAL.Models.MovieDetail", "MovieDetail")
                        .WithMany("Crew")
                        .HasForeignKey("MovieDetailId");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.Genre", b =>
                {
                    b.HasOne("DailyMoviesDAL.Models.MovieDetail", "MovieDetail")
                        .WithMany("Genre")
                        .HasForeignKey("MovieDetailId");

                    b.Navigation("MovieDetail");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.MovieDetail", b =>
                {
                    b.HasOne("DailyMoviesDAL.Models.TrendingMovie", "TrendingMovie")
                        .WithOne("MovieDetail")
                        .HasForeignKey("DailyMoviesDAL.Models.MovieDetail", "TrendingMovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TrendingMovie");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.MovieDetail", b =>
                {
                    b.Navigation("Cast");

                    b.Navigation("Crew");

                    b.Navigation("Genre");
                });

            modelBuilder.Entity("DailyMoviesDAL.Models.TrendingMovie", b =>
                {
                    b.Navigation("MovieDetail");
                });
#pragma warning restore 612, 618
        }
    }
}