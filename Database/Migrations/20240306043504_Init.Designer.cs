﻿// <auto-generated />
using System;
using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Database.Migrations
{
    [DbContext(typeof(MoviesDbContext))]
    [Migration("20240306043504_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.1");

            modelBuilder.Entity("EntityDefinitions.Entities.Movies", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("MovieActors")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieGenre")
                        .HasColumnType("TEXT");

                    b.Property<string>("MoviePlot")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieRatings")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("MovieReleaseDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("MovieTitle")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}
