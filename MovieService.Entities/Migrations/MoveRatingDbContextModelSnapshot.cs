﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MovieService.Entities;

namespace MovieService.Entities.Migrations
{
    [DbContext(typeof(MoveRatingDbContext))]
    partial class MoveRatingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MovieService.Entities.Entities.FilmRate", b =>
                {
                    b.Property<int>("FilmId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("Count")
                        .HasColumnType("bigint");

                    b.Property<long>("Sum")
                        .HasColumnType("bigint");

                    b.HasKey("FilmId");

                    b.ToTable("FilmRates");

                    b.HasData(
                        new
                        {
                            FilmId = 1,
                            Count = 125L,
                            Sum = 700L
                        },
                        new
                        {
                            FilmId = 2,
                            Count = 35L,
                            Sum = 300L
                        },
                        new
                        {
                            FilmId = 3,
                            Count = 80L,
                            Sum = 600L
                        },
                        new
                        {
                            FilmId = 4,
                            Count = 100L,
                            Sum = 700L
                        },
                        new
                        {
                            FilmId = 5,
                            Count = 112L,
                            Sum = 700L
                        },
                        new
                        {
                            FilmId = 6,
                            Count = 100L,
                            Sum = 200L
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
