﻿// <auto-generated />
using System;
using Kolokwium.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Kolokwium.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20200615102655_addedTeamPlayerChampionshipTables")]
    partial class addedTeamPlayerChampionshipTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Kolokwium.Models.Championship", b =>
                {
                    b.Property<int>("IdChampionship")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("OfficialName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("IdChampionship");

                    b.ToTable("Championship");

                    b.HasData(
                        new
                        {
                            IdChampionship = 1,
                            OfficialName = "mistrzostwo",
                            Year = 2020
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Player", b =>
                {
                    b.Property<int>("IdPlayer")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("IdPlayer");

                    b.ToTable("Player");

                    b.HasData(
                        new
                        {
                            IdPlayer = 1,
                            DateOfBirth = new DateTime(1999, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FirstName = "Adam",
                            LastName = "Pierzchala"
                        });
                });

            modelBuilder.Entity("Kolokwium.Models.Team", b =>
                {
                    b.Property<int>("IdTeam")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MaxAge")
                        .HasColumnType("int");

                    b.Property<string>("TeamName")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("IdTeam");

                    b.ToTable("Team");

                    b.HasData(
                        new
                        {
                            IdTeam = 1,
                            MaxAge = 20,
                            TeamName = "hulaho"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
